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

            ProductoIdComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductoIdComboBox.SelectedValuePath = "ProductoId";
            ProductoIdComboBox.DisplayMemberPath = "NombreP";
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

                MessageBox.Show($"Esta entrada no fue encontrada.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

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
                    MessageBox.Show("El Campo (Nombre Provedor) está vacío.\n\nPorfavor, Asigne un Nombre al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombreProvedorTextBox.Clear();
                    NombreProvedorTextBox.Focus();
                    return;
                }
                ProductosBLL.SumarEntradaProductos(Convert.ToInt32(ProductoIdComboBox.SelectedValue), Convert.ToDouble(CantidadTextBox.Text)); //-----------------

                var paso = EntradaProductosBLL.Guardar(entradaProductos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Entrada guardada ", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Entrada no se guardo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void EntradaProductoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (EntradaProductoIdTextBox.Text.Trim() != string.Empty)
                {
                    double.Parse(EntradaProductoIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Entrada Producto Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                EntradaProductoIdTextBox.Text = "0";
                EntradaProductoIdTextBox.Focus();
                EntradaProductoIdTextBox.SelectAll();
            }
        }

        private void CantidadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (CantidadTextBox.Text.Trim() != string.Empty)
                {
                    double.Parse(CantidadTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Cantidad) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Text = "0";
                CantidadTextBox.Focus();
                CantidadTextBox.SelectAll();
            }
        }
    }
}

