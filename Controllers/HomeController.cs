using PanaderiaDonMario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PanaderiaDonMario.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel model = new UsuarioModel();

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Iniciar Sesión";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string password, string ReturnUrl)
        {

            ViewBag.Title = "Iniciar Sesión";

            if (String.IsNullOrWhiteSpace(usuario))
            {
                ModelState.AddModelError("codigo", "Debe ingresar su usuario");

                TempData["errorMessage"] = "Debe ingresar su usuario";
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                ViewBag.userAccess = usuario;
                ModelState.AddModelError("password", "Debe ingresar la contraseña");
                TempData["errorMessage"] = "Debe ingresar su contraseña";
            }

            if (!ModelState.IsValid)
            {
                //return View(ModelState);
                return View();
            }
            Usuario usuario_valido = model.VerificarCuentaporEmail(usuario, password);

            if (usuario_valido == null)
            {
                ViewBag.userAccess = usuario;

                ModelState.AddModelError("codigo", "Usuario y/o password incorrecto");
                TempData["errorMessage"] = "Usuario y/o password incorrecto";

            }
            else
            {
                FormsAuthentication.SetAuthCookie(usuario, false);

                if (usuario_valido != null)
                {
                    //Session["user"] = usuario_valido;
                    Singleton.Instance.id = usuario_valido.ID_User;
                }

                if (String.IsNullOrEmpty(ReturnUrl))
                {
                    TempData["successMessage"] = "Bienvenido!!";
                    return RedirectToAction("Index", "Facturas", null);


                }
                return Redirect(ReturnUrl);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}