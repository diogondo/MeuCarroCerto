using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeuCarroCerto.Models;

namespace MeuCarroCerto.Controllers
{
    public class ResultadoController : Controller
    {
        //
        // GET: /Resultado/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();

        public ActionResult Index(Alternativas alternativas)
        {
            
            
            List<t_carros> carros = new List<t_carros>();
            var teste = db.t_carros.SqlQuery("select * from t_carros;");
            ViewBag.alternativas = alternativas;
            ViewBag.cont=0;
            foreach (var item in teste)
            {
                carros.Add(item);
            
            }

            //carros.Add(db.t_carros.SqlQuery("select * from t_carros;"));
            return View(carros);
        }

    }
}
