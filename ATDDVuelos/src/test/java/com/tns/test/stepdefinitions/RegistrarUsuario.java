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

public class RegistrarUsuario {

	private Utils util = Utils.getInstance();
	private WebDriver driver = util.getWebDriver();	
	
	@Given("^El sistema muestra la aplicacion$")
	public void el_sistema_muestra_la_aplicacion() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		driver.get(Constantes.URL_APLICACION);
	}

	@Given("^el usuario ingresa a la opcion registrarse$")
	public void el_usuario_ingresa_a_la_opcion_registrarse() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement linkRegistrar = driver.findElement(By.linkText("Registrarse"));
		linkRegistrar.click();
	}

	@When("^se ingresa el nombre de usuario \"([^\"]*)\"$")
	public void se_ingresa_el_nombre_de_usuario(String username) throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);
		WebElement inputUserName = util.getWebDriver().findElement(By.id("usuario"));
		inputUserName.sendKeys(username);
	}

	@When("^se ingresa la contraseña \"([^\"]*)\"$")
	public void se_ingresa_la_constraseña(String password) throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement inputPassword = util.getWebDriver().findElement(By.id("password"));
		inputPassword.sendKeys(password);
	}

	@When("^se ingresa la fecha de nacimiento \"([^\"]*)\"$")
	public void se_ingresa_la_fecha_de_nacimiento(String fechaNacimiento) throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement inputFechaNacimiento = util.getWebDriver().findElement(By.id("fechaNacimiento"));
		inputFechaNacimiento.sendKeys(fechaNacimiento);
	}

	@When("^se presiona el boton registrar$")
	public void se_presiona_el_boton_registrar() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		WebElement btnRegistrar = driver.findElement(By.id("btnRegistrarUsuario"));
		btnRegistrar.click();
	}

	@Then("^se inserta el usuario en la base de datos$")
	public void se_inserta_el_usuario_en_la_base_de_datos() throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
		 //driver.manage().timeouts().implicitlyWait(500, TimeUnit.SECONDS);
		new WebDriverWait(driver, 10);
		 Thread.sleep(1000);
		 Alert alert = driver.switchTo().alert();
		 String message = alert.getText();
		 alert.sendKeys("");
		 alert.accept();
		 Assert.assertEquals(Constantes.MENSAJE_EXITO_CREACION_USUARIO, message);
	}	
}
