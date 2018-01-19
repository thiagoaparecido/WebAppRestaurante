using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppRestaurante.Models
{
    public class Restaurante
    {
        public int RestauranteID { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Prato> Prato { get; set; }
    }
}