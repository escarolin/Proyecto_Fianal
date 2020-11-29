using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades{
    public class DevolucionesDetalle{
        [Key]
        public int Id { get; set; }
        public string Cantidad { get; set; }
        public string VentaId { get; set; }
        public int ProductoId { get; set; }
        public int DevolucionId { get; set; }
        public int UsuarioId { get; set; }
        
    }

}