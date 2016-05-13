using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{
    public class BancoSession
    {
        public IList<Filtros> ListaFiltros { get; set; }
        public IList<CriteriosPessoa> ListaCriteriosPessoa { get; set; }
        public IList<MatrizCriterios> ListamatrizCriteios { get; set; }
        private BancoSession()
        {
            this.ListaFiltros = new List<Filtros>();
            this.ListaCriteriosPessoa = new List<CriteriosPessoa>();
            this.ListamatrizCriteios = new List<MatrizCriterios>();
        }


        public static BancoSession CriarConexaoBancoSession()
        {
            BancoSession banco = HttpContext.Current.Session["bd"] as BancoSession;
            if (banco == null)
                HttpContext.Current.Session["bd"] = new BancoSession();

            return HttpContext.Current.Session["bd"] as BancoSession;
        }

        public void LimparBanco()
        {
            HttpContext.Current.Session["bd"] = null;
        }
    }
}