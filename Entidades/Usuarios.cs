using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Final.Entidades{
    public class Usuarios{
        [Key]
        public int UsuarioId { get; set; }
        public string   Nombres { get; set; }

        public string Apellidos { get; set; }
        public string Clave { get; set; }

        public DateTime Fecha { get; set; }= DateTime.Now;
        public string UsuarioN { get; set; }
        
    }
}