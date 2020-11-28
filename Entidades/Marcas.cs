using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Proyecto_Final.Entidades{
    public class Marcas{
        [Key]
        public int MarcaId { get; set; }
        public string NombreMarca { get; set; }
        public string Descripcion { get; set; }
    }
}