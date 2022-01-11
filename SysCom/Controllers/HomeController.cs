using SysCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SysCom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(String message = "")
        {
            ViewBag.Message = message;

            return View();
        }


        [HttpPost]
        public ActionResult Login(string usuario, string contrasena)
        {
            //Comprobar que no esten vacios

            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contrasena))
            {
                bdsyscomEntities db = new bdsyscomEntities();
                var user = db.empleados.FirstOrDefault(e => e.Usuario == usuario && e.Contraseña == contrasena);


                Session["Usuario"] = user;

                if (user != null)
                {
                    //se encontro un usuario
                    FormsAuthentication.SetAuthCookie(user.Usuario + "|"+ user.Tipo, true);

                    return RedirectToAction("Index", "Inicio");
                }

                else
                {
                    //Error
                    return RedirectToAction("Index", new { message = "No se encontraron tus datos,  usuario y/o contraseña incorrecta" });

                }
            }
            else
            {
                //error 
                return RedirectToAction("Index", new { message = "Favor de llenar los campos para iniciar sesión" });
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}