using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{

    public class CarrosXAlternativas
    {
      public long idCarro { get; set; }    
      public int necessidade{ get; set; }
      public double necessidadePercent { get; set; }
      public int qualidade { get; set; }
      public double qualidadePercent { get; set; }
      public int seguranca { get; set; }
      public double segurancaPercent { get; set; }
      public int valor { get; set; }
      public double valorPercent { get; set; }
      public int marketing { get; set; }
      public double marketingPercent { get; set; }
      public double vetDecisao { get; set; }
      public CarrosXAlternativas()
      {

      }
    }
}