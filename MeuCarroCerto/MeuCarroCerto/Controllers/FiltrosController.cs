using MeuCarroCerto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuCarroCerto.Controllers
{
    public class FiltrosController : Controller
    {
        //
        // GET: /Filtros/
        private EntidadesMeuCarroCertoDB db = new EntidadesMeuCarroCertoDB();
        
        public ActionResult Index()
        {
            ViewBag.qtd = new SelectList(db.t_parametros.Where(i => i.tipo == "ocupantes"), "desc", "desc");
            ViewBag.carroceria = new SelectList(db.t_carrocerias, "codigo", "nome");
            ViewBag.valor = new SelectList(db.t_parametros.Where(i => i.tipo == "preco"), "desc", "desc");
            ViewBag.ano = new SelectList(db.t_parametros.Where(i => i.tipo == "ano"), "desc", "desc");
            return View();
        }
        [HttpPost]
        public ActionResult Index(MeuCarroCerto.Models.Filtros filtro)
        {
            //List<t_carros> carros = new List<t_carros>();
            //carros.Add(db.t_carros.Where(i => i.qtd_ocupantes == filtro.qtd_ocupante));
           // && i.valor.Equals(filtro.valor)
           var carros = db.t_carros.Where(i => i.qtd_ocupantes == filtro.qtd_ocupante  && i.ano >= filtro.ano1 && i.ano <= filtro.ano2 );
           var teste = db.t_carros.SqlQuery("select * from t_carros where qtd_ocupantes=" + filtro.qtd_ocupante + " and codigo_tipo_carroceria=" + filtro.tipo_carroceria + " and ano>=" + filtro.ano1 + " and ano <=" + filtro.ano2 + ";");
            
            // var carros = db.t_carros.Where(i => i.qtd_ocupantes == filtro.qtd_ocupante);
            
            var carros2 = teste.FirstOrDefault<t_carros>();

            foreach (var item in teste)
            {
                Console.WriteLine("nome={0}, Carroceria={1}", item.nome, item.codigo_tipo_carroceria);
            }

            BancoSession bd = BancoSession.CriarConexaoBancoSession();
            bd.ListaFiltros.Add(filtro);
            
            return RedirectToAction("Index", "CriteriosPessoa");
        }

    }
}
