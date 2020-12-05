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
        
        //——————————————————————————————————————————————————————————————[ Nuevo ]———————————————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (EntradaProductoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida\n\nNo se pudo validar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            EntradaProductos encontrado = EntradaProductosBLL.Buscar(int.Parse((EntradaProductoIdTextBox.Text)));

            if (encontrado != null)
            {
                this.entradaProductos = encontrado;
                Cargar();
            }
            else
            {
                this.entradaProductos = new EntradaProductos();
                this.DataContext = this.entradaProductos;

                MessageBox.Show($"Este Contacto no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

                Limpiar();
                EntradaProductoIdTextBox.SelectAll();
                EntradaProductoIdTextBox.Focus();
            }
        }
        //——————————————————————————————————————————————————————————————[ Guardar ]———————————————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;
                     //—————————————————————————————————[ NombreCompleto ]—————————————————————————————————
                if (NombreProvedorTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Completo) está vacío.\n\nPorfavor, Asigne un Nombre al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreProvedorTextBox.Clear();
                    NombreProvedorTextBox.Focus();
                    return;
                }
            }

        
        
        }
         private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ClientesBLL.Eliminar(int.Parse(EntradaProductoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

       