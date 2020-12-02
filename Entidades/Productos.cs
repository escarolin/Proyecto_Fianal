using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Controls;

namespace Proyecto_Final.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public string NombreP { get; set; }
        public string Descripcion { get; set; }
        public int MarcaId { get; set; }
        public float Existencia { get; set; }
        public double Precio { get; set; }
        public double Ganacia { get; set; }
        public int Cantidad { get; set; }
        public double Itebis { get; set; }
        public double Costo { get; set; }
        public DateTime FechaP { get; set; } = DateTime.Now;
    }
}