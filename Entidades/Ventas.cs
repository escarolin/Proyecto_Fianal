using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades{
    public class Ventas{
        public int VentaId { get; set; }
        public float ITBIS { get; set; }

        public double Total { get; set; }
        public int UsuarioId { get; set; }
        public double Ganacia { get; set; }
        public DateTime FechaF { get; set; }=DateTime.Now;
    }
}