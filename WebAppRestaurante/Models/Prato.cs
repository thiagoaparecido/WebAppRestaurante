using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppRestaurante.Models
{
    public class Prato
    {
        public int PratoID { get; set; }
        public string Descricao { get; set; }

        //[DisplayFormat(DataFormatString = "{0:#.####}")]
        public double Preco { get; set; }

        public int RestauranteID { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}