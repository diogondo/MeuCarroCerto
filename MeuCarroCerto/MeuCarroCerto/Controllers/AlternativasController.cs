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
           

            

            return RedirectToAction("Index2", "Resultado",alternativas);
        }


    }
}
