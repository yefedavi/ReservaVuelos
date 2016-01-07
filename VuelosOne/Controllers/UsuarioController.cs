using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VuelosOne.Models;
using VuelosOne.BussinesClass;

namespace VuelosOne.Controllers
{
    public class UsuarioController : Controller
    {
        private static String EXITO="Exitoso";
        private static String FALLIDO = "Fallido";
        //
        // GET: /Usuario/
        //Interfaz de negocio de la administraciòn de usuarios
        public IAdministrarUsuarios AdminUsuarios { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public UsuarioController()
        {
            AdminUsuarios = new AdministrarUsuarios();
        }

        public UsuarioController(IAdministrarUsuarios iAdministrarUsuarios)
        {
            AdminUsuarios = iAdministrarUsuarios;
        }

        /// <summary>
        /// Mètodo encargado de cargar la pagina principal de la aplicaciòn
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }

        /// <summary>
        /// Mètodo encargado de llaamar el mètodo de negocio para la creaciòn
        /// de un usuario en la base de datos
        /// </summary>
        /// <param name="usuario">usuario que se va a crear</param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public String IngresarUsuario(Usuario usuario)
        {
            Boolean respuesta = AdminUsuarios.CrearUsuario(usuario);
            if (respuesta)
            {
                return EXITO;
            }
            else
            {
                return FALLIDO;
            }

        }

        /// <summary>
        /// Mètodo encargado de loguear un usuario a la aplicaciòn
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public String LoguearUsuario(Usuario usuario) 
        {
            Boolean respuesta = AdminUsuarios.LoguearUsuario(usuario.Username, usuario.Password);
            if (respuesta)
            {
                //Almaceno el usuario en sesion
                Session["usuario"] = usuario.Username;
                return EXITO;
            }
            else
            {
                return FALLIDO;
            }
        }

        /// <summary>
        /// Método encargado de llamar la pagina registrar usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        /// <summary>
        /// Mètodo encargado de llamar la pagina login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View("");
        }

        /// <summary>
        /// Mètodo encargado de desloguear al usuario de la aplicacion
        /// </summary>
        /// <returns></returns>
        public ActionResult Salir()
        {
            Session["usuario"] = null;
            return View("~/Views/Index.cshtml");
        }

    }
}
