using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class CriteriosPessoaController : Controller
    {
        //
        // GET: /CriteriosPessoa/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();
        public ActionResult Index()
        {
            ViewBag.criterio = new SelectList(db.t_parametros.Where(i => i.tipo == "criterio"), "peso", "desc");
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(MeuCarroCerto.Models.CriteriosPessoa criteriosPessoa)
        {
            MatrizCriterios matrizCriteios = new MatrizCriterios();
            matrizCriteios.CarregaMatriz(criteriosPessoa);

            double rc = matrizCriteios.Rc()*100;
            double autovero = matrizCriteios.autoVetor();
            double necessidade = matrizCriteios.vNormaNecessidade();
            double qualidade = matrizCriteios.vNormaQualidade();
            double seguranca = matrizCriteios.vNormaSeguranca() ;
            double valor = matrizCriteios.vNormaValor();
            double marketing = matrizCriteios.vNormaMarketing();

            BancoSession bd = BancoSession.CriarConexaoBancoSession();
            bd.ListaCriteriosPessoa.Add(criteriosPessoa);
            bd.ListamatrizCriteios.Add(matrizCriteios);

            ViewBag.criterio = new SelectList(db.t_parametros.Where(i => i.tipo == "criterio"), "id", "desc");

            return RedirectToAction("Index", "Alternativas");
        }
    }
}
