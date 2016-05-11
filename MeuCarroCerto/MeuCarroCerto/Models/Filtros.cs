using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{
    public class Filtros
    {
        public int qtd_ocupante { get; set; }    
        public string tipo_carroceria{ get; set; }
        public string valor1 { get; set; }
        public string valor2 { get; set; }
        public int ano1 { get; set; }
        public int ano2 { get; set; }
        public Filtros()
        {

        }

    }
}