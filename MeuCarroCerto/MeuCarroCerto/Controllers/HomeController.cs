using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem-vindo(a)";
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
