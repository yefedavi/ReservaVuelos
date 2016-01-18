package com.tns.test.stepdefinitions;

import java.util.concurrent.TimeUnit;

import org.junit.Assert;
import org.openqa.selenium.Alert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.tns.test.util.Constantes;
import com.tns.test.util.Utils;

import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;

public class LoguearUsuario {

	private Utils util = Utils.getInstance();
	private WebDriver driver = util.getWebDriver();	
	
	@Given("^El sistema carga la pagina inicial$")
	public void el_sistema_carga_la_pagina_inicial() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		driver.get(Constantes.URL_APLICACION);
	}

	@Given("^el usuario ingresa a la opcion iniciar sesion$")
	public void el_usuario_ingresa_a_la_opcion_iniciar_sesion() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement linkIniciarSesion = driver.findElement(By.linkText("Iniciar sesion"));
		linkIniciarSesion.click();		
	}

	@When("^se ingresa el nombre de usuario registrado \"([^\"]*)\"$")
	public void se_ingresa_el_nombre_de_usuario_registrado(String username) throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
		WebElement inputUserName = util.getWebDriver().findElement(By.id("usuario"));
		inputUserName.sendKeys(username);
	}

	@When("^se ingresa la contraseña previamente registrada \"([^\"]*)\"$")
	public void se_ingresa_la_contraseña_previamente_registrada(String password) throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement inputPassword = util.getWebDriver().findElement(By.id("password"));
		inputPassword.sendKeys(password);
	}

	@When("^se presiona el boton ingresar$")
	public void se_presiona_el_boton_ingresar() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement btnIngresar = driver.findElement(By.id("btnLoguearApp"));
		btnIngresar.click();
	}

	@Then("^el usuario ingresa a las funciones de la aplicacion$")
	public void el_usuario_ingresa_a_las_funciones_de_la_aplicacion() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		new WebDriverWait(driver, 10);
		 Thread.sleep(1000);
		 Alert alert = driver.switchTo().alert();
		 String message = alert.getText();
		 alert.sendKeys("");
		 alert.accept();
		 Assert.assertEquals(Constantes.MENSAJE_EXITO_LOGUEO_EXITOSO, message);
	}	
}
