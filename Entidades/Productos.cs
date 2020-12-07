using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public String NombreP { get; set; }
        public String Descripcion { get; set; }
        public int MarcaId { get; set; }
        public double Precio { get; set; }
        public double Ganacia { get; set; }
        public double Itebis { get; set; }
        public double Costo { get; set; }
        public double Existencia { get; set; }
        public DateTime FechaP { get; set; } = DateTime.Now;
    }
}