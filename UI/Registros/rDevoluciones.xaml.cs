using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proyecto_Final.Entidades;
using Proyecto_Final.BLL;


namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for Devoluciones.xaml
    /// </summary>
    public partial class rDevoluciones : Window
    {
        private Devoluciones Devoluciones = new Devoluciones();
        public rDevoluciones()
        {
            InitializeComponent();
            this.DataContext = Devoluciones;
           
            
        }

         private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Devoluciones;
        }
        //Limpiar
        private void Limpiar()
        {
            this.Devoluciones = new Devoluciones();
            this.DataContext = Devoluciones;
        }
        //Validar
        
        
    }
}