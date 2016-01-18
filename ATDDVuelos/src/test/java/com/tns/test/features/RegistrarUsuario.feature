# encoding: iso-8859-1
Feature: Registrar usuario aplicacion

  Background: 
    Given El sistema carga la pagina inicial

  Scenario Outline: Registrar usuario aplicacion
    Given el usuario ingresa a la opcion registrarse
    When se ingresa el nombre de usuario <nombreUsuario>
    And se ingresa la contraseña <contrasena>
    And se ingresa la fecha de nacimiento <fechaNacimiento>
    And se presiona el boton registrar
    Then se inserta el usuario en la base de datos

    Examples: 
      | nombreUsuario | contrasena | fechaNacimiento |
      | "coco"        | "coco123"  | "12/12/1990"    |
