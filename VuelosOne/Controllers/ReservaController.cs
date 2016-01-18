using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuelosOne.BussinesClass;
using VuelosOne.Models;
namespace VuelosOne.Controllers
{
    public class ReservaController : Controller
    {
        private static String EXITO = "Exitoso";
        private static String FALLIDO = "Fallido";

        public IAdministrarUsuarios AdminUsuarios { get; set; }
        public IAdministrarReservas AdminReservas { get; set; }
        public IAdministrarVuelos AdminVuelos { get; set; }
        //
        // GET: /Reserva/
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ReservaController()
        {
            AdminUsuarios = new AdministrarUsuarios();
            AdminReservas = new AdministrarReservas();
            AdminVuelos = new AdministrarVuelos();
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="administrarUsuarios"></param>
        /// <param name="administrarReservas"></param>
        /// <param name="administrarVuelos"></param>
        public ReservaController(IAdministrarUsuarios administrarUsuarios, IAdministrarReservas administrarReservas,IAdministrarVuelos administrarVuelos)
        {
            AdminUsuarios = administrarUsuarios;
            AdminReservas = administrarReservas;
            AdminVuelos = administrarVuelos;
        }

        /// <summary>
        /// Metodo encargado de cargar la pagina principal de reservas
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("ConsultaReservas");
        }

        /// <summary>
        /// Mètodo encargado de realizar la reserva de un vuelo
        /// para un usuario
        /// </summary>
        /// <param name="codigoVuelo"></param>
        /// <returns></returns>
        [HttpPost]
        public String RealizarReserva(string codigoVuelo)
        {
            String resultado = EXITO;
            string usernameActual =(String) Session["usuario"];
            // Realizo la consulta del usuario en la base de datos.
            Usuario usuarioReserva = AdminUsuarios.ConsultarUsuario(usernameActual);
            // Realizo la consulta del vuelo en la base de datos
            Vuelo vueloReserva = AdminVuelos.consultarVueloId(int.Parse(codigoVuelo));

            if ((usuarioReserva != null) && (vueloReserva != null))
            {
               Boolean seReservo= AdminReservas.RealizarReserva(vueloReserva, usuarioReserva.Username);
               if (seReservo)
               {
                   resultado = EXITO;
               }
               else
               {
                   resultado = FALLIDO;
               }
            }
 
            return resultado;
        }

        /// <summary>
        /// Mètodo encargado de redireccionar a confirmar una reserva
        /// </summary>
        /// <param name="codigoVuelo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConfirmarReserva(string codigoVuelo)
        {
            Vuelo vueloConfirmacion = AdminVuelos.consultarVueloId(int.Parse(codigoVuelo));
            return View("ConfirmarReserva", vueloConfirmacion);
        }

    }
}
