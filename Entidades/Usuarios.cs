using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Proyecto_Final.Entidades{
    public class Usuarios{
        public int UsuarioId { get; set; }
        public string   Nombres { get; set; }

        public string Apellido { get; set; }
        public string Clave { get; set; }

        public DateTime Fecha { get; set; }= DateTime.Now;
        public string UsuarioN { get; set; }
        
    }
}