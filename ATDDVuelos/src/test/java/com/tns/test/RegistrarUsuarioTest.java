package com.tns.test;

import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(features = {"src/test/java/com/tns/test/features/RegistrarUsuario.feature"})
public class RegistrarUsuarioTest {

}