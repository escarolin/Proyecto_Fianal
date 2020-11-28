using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades{
    public class EntradaProductos{
        [Key]
        public int EntradaProductoId { get; set; }
        public string NombreProvedor { get; set; }
        public double PrecioProducto { get; set; }
        public float Cantidad { get; set; }
        public DateTime FechaEntrada { get; set; }
    }
}