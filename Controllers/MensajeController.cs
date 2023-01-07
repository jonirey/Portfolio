using Microsoft.AspNetCore.Mvc;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using portfolioMVC.Models;
using static System.Net.WebRequestMethods;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Net;

namespace portfolioMVC.Controllers
{
    public class MensajeController : Controller
    {
        IFirebaseClient cliente;
      

        public MensajeController()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = "secreto de la base ",
                BasePath = "  link de la base "
            };
            cliente = new FirebaseClient(config);
        }


        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Mensaje oMensaje )
        {
           var clienteweb = new WebClient();
            string secreto = "secret key del captcha";
            var respuesta = HttpContext.Request.Form["g-recaptcha-response"];
            var resultado = clienteweb.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secreto, respuesta));
            var obj = JObject.Parse(resultado);
            var status = (bool)obj.SelectToken("success");

            if (!status)
            {
                TempData["Error"] = "no se pudo enviar el mensaje, complete el reCaptcha";
                //return RedirectToAction("Index", "Home" );
                return Redirect("/Home/Index#contact");

            }

            string idGenerado = Guid.NewGuid().ToString("N");
            DateTime today = DateTime.Today;
            oMensaje.date = today;
            SetResponse response = cliente.Set("mensajes/" + idGenerado, oMensaje);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               
                 return View();
              

            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Enviado()
        {
            return View();
        }
    }
}
