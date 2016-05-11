using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuCarroCerto.Models;
namespace MeuCarroCerto.Controllers
{
    public class AlternativasController : Controller
    {
        //
        // GET: /Alternativas/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Alternativas alternativas)
        {
            if (alternativas.trio_eletrico = true) {
                alternativas.valor_do_seguro = true;
            };

            

            return RedirectToAction("Index", "Resultado",alternativas);
        }


    }
}
