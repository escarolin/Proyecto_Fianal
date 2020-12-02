using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direcion { get; set; }
        public long Cedula { get; set; }
        public long Telefono { get; set; }
        public long Celular { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public DateTime FechaR { get; set; } = DateTime.Now;
    }
}