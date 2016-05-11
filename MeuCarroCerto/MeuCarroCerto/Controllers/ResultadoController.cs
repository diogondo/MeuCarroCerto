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
            
            MeuCarroCerto.Models.Filtros filtros = new MeuCarroCerto.Models.Filtros();
            List<t_carros> carros = new List<t_carros>();
            BancoSession bd = BancoSession.CriarConexaoBancoSession();
            filtros = bd.ListaFiltros[0];

            var teste = db.t_carros.SqlQuery("select * from t_carros where valor between " + filtros.valor1 + " and " + filtros.valor2 + " and ano between " + filtros.ano1 + " and " + filtros.ano2 + " and qtd_ocupantes=" + filtros.qtd_ocupante + " and codigo_tipo_carroceria = " + filtros.tipo_carroceria + ";");
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
