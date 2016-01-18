# encoding: iso-8859-1
Feature: Loguear usuario aplicacion

  Background: 
    Given El sistema carga la pagina inicial

  Scenario Outline: Loguear usuario aplicacion
    Given el usuario ingresa a la opcion iniciar sesion
    When se ingresa el nombre de usuario registrado <nombreUsuario>
    And se ingresa la contraseña previamente registrada <contrasena>
    And se presiona el boton ingresar
    Then el usuario ingresa a las funciones de la aplicacion

    Examples: 
      | nombreUsuario | contrasena |
      | "yefedavi"        | "yefedavi123"  |
