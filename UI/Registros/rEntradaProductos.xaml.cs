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
    /// Interaction logic for EntradaProductos.xaml
    /// </summary>
    public partial class rEntradaProductos : Window
    {
        private EntradaProductos entradaProductos = new EntradaProductos();
        public rEntradaProductos()
        {
            InitializeComponent();
            this.DataContext = entradaProductos;
           
            //—————————————————————————————————————[ ComboBox UsuarioId ]—————————————————————————————————————
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";
        }

         private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = entradaProductos;
        }
        //Limpiar
        private void Limpiar()
        {
            this.entradaProductos = new EntradaProductos();
            this.DataContext = entradaProductos;
        }
        //Validar
        
        
    }
}

       