using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{
    public class Auxiliar
    {
        //
        // GET: /Auxiliar/

        public static int ObterMarca()
        {

            int idmodelo = (int)HttpContext.Current.Session["marcas"];

            return idmodelo;
        }

    }
}
