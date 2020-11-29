using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades{
    public class Clientes{
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direcion { get; set; }
        public int Cedula { get; set; }
        public int Telefono { get; set; }
        public int Celular { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }   
        public DateTime FechaR { get; set; }= DateTime.Now;
    }

}