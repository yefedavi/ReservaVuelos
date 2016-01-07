using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelosOne.Controllers;
using VuelosOne.Models;
using System.Web.Mvc;
using VuelosOne.BussinesClass;
using Moq;
using VuelosOne.Tests.Mocks;
using System.Web;
using MvcContrib.TestHelper;

namespace VuelosOne.Tests.Controllers
{


    [TestClass]
    public class UsuarioControllerTest
    {
        public static String EXITO = "Exitoso";
        public static String FALLIDO = "Fallido";

        private Mock<IAdministrarUsuarios> objetoMock;
        private UsuarioController usuarioControlador;

        [TestInitialize()]
        public void Initialize() {
            objetoMock = new Mock<IAdministrarUsuarios>();
            AdministrarUsuarioMOCK mock = new AdministrarUsuarioMOCK();
            TestControllerBuilder builder = new TestControllerBuilder();
            usuarioControlador = new UsuarioController(mock);
            builder.InitializeController(usuarioControlador);
        }

        [TestMethod]
        public void CargarUsuarioControllerTest()
        {
            // Arrange

            // Act
            ViewResult result = usuarioControlador.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [TestMethod]
        public void IngresarUsuarioTest()
        {
            //Arrange
            Usuario user = new Usuario();
            user.Codigo = 999;
            user.Username = "1";
            user.Password = "prueba123";
            user.FechaNacimiento = new DateTime();

            //Act
            String resultado = usuarioControlador.IngresarUsuario(user);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(EXITO, resultado);
        }

        [TestMethod]
        public void IngresarUsuarioTestFalla()
        {
            //Arrange
            var objetoMock = new Mock<IAdministrarUsuarios>();
            Usuario user = new Usuario();
            user.Codigo = 999;
            user.Username = "2";
            user.Password = "prueba123";
            user.FechaNacimiento = new DateTime();

            //Act
            String resultado = usuarioControlador.IngresarUsuario(user);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(FALLIDO, resultado);
        }

        [TestMethod]
        public void LoguearUsuarioExitosoAplicacionTest()
        {
            //Arrange
            Usuario user = new Usuario();
            user.Username = "UsuarioLogin";
            user.Password = "contra123";

            //Act
            String resultado = usuarioControlador.LoguearUsuario(user);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(EXITO, resultado);
        }

        [TestMethod]
        public void LoguearUsuarioFallidoAplicacionTest()
        {
            //Arrange
            Usuario user = new Usuario();
            user.Username = "UsuarioLogin";
            user.Password = "contra1";

            //Act
            String resultado = usuarioControlador.LoguearUsuario(user);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(FALLIDO, resultado);
        }

        [TestMethod]
        public void CargarVistaRegistrarUsuario()
        {
            ViewResult result = usuarioControlador.RegistrarUsuario() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [TestMethod]
        public void CargarVistaLoginUsuario()
        {
            ViewResult result = usuarioControlador.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [TestMethod]
        public void SalirAplicacion()
        {
            //Act
            ViewResult result = usuarioControlador.Salir() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }
    }
}
