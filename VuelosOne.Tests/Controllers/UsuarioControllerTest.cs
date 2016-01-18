using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelosOne.Controllers;
using VuelosOne.Models;
using System.Web.Mvc;
using VuelosOne.BussinesClass;
using Moq;
using VuelosOne.Tests.Mocks;
using System.Web;
using MvcContrib.TestHelper;
using NUnit.Framework;

namespace VuelosOne.Tests.Controllers
{


    [TestFixture]
    public class UsuarioControllerTest
    {
        public static String EXITO = "Exitoso";
        public static String FALLIDO = "Fallido";

        private Mock<IAdministrarUsuarios> objetoMock;
        private UsuarioController usuarioControlador;

        [SetUp]
        public void Initialize() {
            objetoMock = new Mock<IAdministrarUsuarios>();
            AdministrarUsuarioMOCK mock = new AdministrarUsuarioMOCK();
            TestControllerBuilder builder = new TestControllerBuilder();
            usuarioControlador = new UsuarioController(mock);
            builder.InitializeController(usuarioControlador);
        }

        [Test]
        public void CargarUsuarioControllerTest()
        {
            // Arrange

            // Act
            ViewResult result = usuarioControlador.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void CargarVistaRegistrarUsuario()
        {
            ViewResult result = usuarioControlador.RegistrarUsuario() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
        public void CargarVistaLoginUsuario()
        {
            ViewResult result = usuarioControlador.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [Test]
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
