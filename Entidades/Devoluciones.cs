using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Proyecto_Final.Entidades
{
    public class Devoluciones
    {
        [Key]
        public int DevolucionId { get; set; }
        public int ClienteId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double TotalDevoluciones { get; set; }

        [ForeignKey("DevolucionId")]
        public virtual List<DevolucionesDetalle> Detalle { get; set; } = new List<DevolucionesDetalle>();

        [ForeignKey("ClienteId")]
        public Clientes clientes { get; set; }
    }
}