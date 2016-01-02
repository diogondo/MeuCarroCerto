using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeuCarroCerto.Models
{
    [MetadataType(typeof(MarcasMetadado))]
    public partial class t_marcas
    {

    }

    public class MarcasMetadado
    {
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(250, ErrorMessage = "O Nome deve possuir no máximo 250 caracteres")]
        public string nome { get; set; }
    }
}