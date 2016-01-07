using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuelosOne.BussinesClass;
using VuelosOne.Models;

namespace VuelosOne.Controllers
{
    public class VueloController : Controller
    {
        private const string CON_RESULTADOS = "conResultados";
        private const string SIN_RESULTADOS = "sinResultados";
        //
        // GET: /Vuelo/
        public IAdministrarVuelos AdminVuelos;

        /// <summary>
        /// Controlador de la clase vuelo controller
        /// </summary>
        public VueloController()
        {
            AdminVuelos = new AdministrarVuelos();
        }
        /// <summary>
        /// Controlador de la clase vuelo controller,con un parametro adicional
        /// </summary>
        /// <param name="iAdministrarVuelos"></param>
        public VueloController(IAdministrarVuelos iAdministrarVuelos)
        {
            AdminVuelos = iAdministrarVuelos;
        }

        /// <summary>
        /// Mètodo que hace cargar la pagina principal de consulta de vuelos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ListarCiudades();
            return View("ConsultaVuelos");
        }

        /// <summary>
        /// Mètodo encargado de listar las ciudades donde vuelan las aerolineas
        /// </summary>
        /// <returns></returns>
        public ActionResult ListarCiudades()
        {
            List < Ciudad > ciudades= AdminVuelos.ObtenerCiudadesVuelos();
            var list = new SelectList(ciudades, "Codigo", "Nombre");
            ViewData["ciudades"] = list;
            return View();
        }
        /// <summary>
        /// Mètodo encargado de listar todos los vuelos entre dos ciudades de las 
        /// diferentes aerolineas
        /// </summary>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult ListarVuelosTipoHorario(string ciudadOrigen,String ciudadDestino)
        {
            Ciudad origen=AdminVuelos.obtenerCiudadCodigo(ciudadOrigen);
            Ciudad destino=AdminVuelos.obtenerCiudadCodigo(ciudadDestino);
            List<Vuelo> vuelosDisponibles = AdminVuelos.ConsultarVuelosDisponiblesHorarios(origen,destino);
            if (vuelosDisponibles.Count > 0)
            {
                ViewBag.HayRegistros = CON_RESULTADOS;  
            }
            else
            {
                ViewBag.HayRegistros = SIN_RESULTADOS;
            }

            return PartialView("VuelosPartialView", vuelosDisponibles);
        }

        /// <summary>
        /// Mètodo encargado de listar todos los vuelos entre dos ciudades de las 
        /// diferentes aerolineas ,organizado por tarifa
        /// </summary>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <returns></returns>
        public PartialViewResult ListarVuelosTipoTarifa(string ciudadOrigen, String ciudadDestino)
        {
            Ciudad origen = AdminVuelos.obtenerCiudadCodigo(ciudadOrigen);
            Ciudad destino = AdminVuelos.obtenerCiudadCodigo(ciudadDestino);
            List<Vuelo> vuelosDisponibles = AdminVuelos.ConsultarVuelosDisponiblesTarifa(origen, destino);
            if (vuelosDisponibles.Count > 0)
            {
                ViewBag.HayRegistros = CON_RESULTADOS;
            }
            else
            {
                ViewBag.HayRegistros = SIN_RESULTADOS;
            }

            return PartialView("VuelosPartialView", vuelosDisponibles);
        }

    }
}
