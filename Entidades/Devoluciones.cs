using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades{
    public class Devoluciones{
        [Key]
        public int DevolucionId { get; set; }
        public string ClienteId { get; set; }
        public string VentaId { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }= DateTime.Now;
    }

}