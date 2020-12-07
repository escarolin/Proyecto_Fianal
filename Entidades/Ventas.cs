using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proyecto_Final.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public double ITBIS { get; set; }
        public double Total { get; set; }
        public double Ganacia { get; set; }
        public DateTime FechaF { get; set; } = DateTime.Now;

        [ForeignKey("VentaId")]
        public virtual List<VentasDetalle> Detalle { get; set; } = new List<VentasDetalle>();

    }
}