using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Proyecto_Final.Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int Cantidadv { get; set; }
        public double Precio { get; set; }
        public int ProductoId { get; set; }

        //———————————————————————————[ ForeingKeys ]———————————————————————————
        [ForeignKey("ProductoId")]
        public Productos productos { get; set; } = new Productos();
    }
}