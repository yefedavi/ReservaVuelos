using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VuelosOne.BussinesClass;
using VuelosOne.Controllers;
using VuelosOne.Tests.Mocks;

namespace VuelosOne.Tests.Controllers
{
    [TestClass]
    public class VueloControllerTest
    {
        private const string CON_RESULTADOS = "conResultados";
        private const string SIN_RESULTADOS = "sinResultados";

        private VueloController VueloControlador;

        [TestInitialize()]
        public void Inicializar()
        {
            AdministrarVuelosMOCK mockVuelos=new AdministrarVuelosMOCK();
            VueloControlador = new VueloController(mockVuelos);

        }

        [TestMethod]
        public void CargarConsultaVuelosTest()
        {
            // Arrange

            // Act
            ViewResult result = VueloControlador.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }

        [TestMethod]
        public void ListarVuelosDisponiblesTipoHorarioExitosaTest()
        {
            // Arrange
            string codigoCiudadOrigen = "1";
            string codigoCiudadDestino = "2";

            // Act
            PartialViewResult result = VueloControlador.ListarVuelosTipoHorario(codigoCiudadOrigen, codigoCiudadDestino);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(PartialViewResult), result.GetType());
        }

        [TestMethod]
        public void ListarVuelosDisponiblesTipoHorarioFallidaTest()
        {
            // Arrange
            string codigoCiudadOrigen = "3";
            string codigoCiudadDestino = "3";

            // Act
            PartialViewResult result = VueloControlador.ListarVuelosTipoHorario(codigoCiudadOrigen, codigoCiudadDestino);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(PartialViewResult), result.GetType());
        }

        [TestMethod]
        public void ListarVuelosDisponiblesTipoTarifaExitosaTest()
        {
            // Arrange
            string codigoCiudadOrigen = "1";
            string codigoCiudadDestino = "2";

            // Act
            PartialViewResult result = VueloControlador.ListarVuelosTipoTarifa(codigoCiudadOrigen, codigoCiudadDestino);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(PartialViewResult), result.GetType());
        }

        [TestMethod]
        public void ListarVuelosDisponiblesTipoTarifaFallidaTest()
        {
            // Arrange
            string codigoCiudadOrigen = "3";
            string codigoCiudadDestino = "3";

            // Act
            PartialViewResult result = VueloControlador.ListarVuelosTipoTarifa(codigoCiudadOrigen, codigoCiudadDestino);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(PartialViewResult), result.GetType());
        }
    }
}
