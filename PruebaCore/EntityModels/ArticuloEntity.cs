using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaCore.EntityModels
{
    public class ArticuloEntity
    {
        [Key]
        public int Sku_ID { get; set; }
        public string Sku_Codigo { get; set; }
        public string Sku_NumeroSerie { get; set; }
        public string Sku_Descripcion { get; set; }
        public string Sku_Cantidad { get; set; }

        public int Sku_Cat_ID { get; set; }

        public int Sku_Sub_Cat_ID { get; set; }
        public string Sku_Latitud { get; set; }
        public string Sku_Longitud { get; set; }
    }
}
