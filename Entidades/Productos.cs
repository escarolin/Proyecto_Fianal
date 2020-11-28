using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Final.Entidades{
    public class Productos{
        [Key]
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public string Descripcion { get; set; }

    }
}