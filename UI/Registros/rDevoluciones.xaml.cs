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
//Using agregados
using Proyecto_Final.BLL;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.UI.Registros
{
    public partial class rDevoluciones : Window
    {
        private Devoluciones devoluciones = new Devoluciones();
        public rDevoluciones()
        {
            InitializeComponent();
            this.DataContext = devoluciones;
            //—————————————————————————————————————[ ComboBox EstudianteId ]—————————————————————————————————————
            ClienteIdComboBox.ItemsSource = ClientesBLL.GetClientes();
            ClienteIdComboBox.SelectedValuePath = "ClienteId";
            ClienteIdComboBox.DisplayMemberPath = "Nombre";
            //—————————————————————————————————————[ ComboBox LibroId ]—————————————————————————————————————
            ProductoIdComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductoIdComboBox.SelectedValuePath = "ProductoId";
            ProductoIdComboBox.DisplayMemberPath = "NombreP";
        }
        //——————————————————————————————————————————————————————————————[ Cargar ]———————————————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = devoluciones;
        }
        //——————————————————————————————————————————————————————————————[ Limpiar ]——————————————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.devoluciones = new Devoluciones();
            this.DataContext = devoluciones;
        }
        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (DevolucionesIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Devoluciones encontrado = DevolucionesBLL.Buscar(devoluciones.DevolucionId);

            if (encontrado != null)
            {
                devoluciones = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show($"Esta Devolución no fue encontrado.\n\nAsegúrese que existe o cree una nueva.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                DevolucionesIdTextbox.SelectAll();
                DevolucionesIdTextbox.Focus();
            }
        }
        //——————————————————————————————————————————————————————————————[ Agregar Fila ]———————————————————————————————————————————————————————————————
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            //—————————————————————————————————[ Libro Id ]—————————————————————————————————
            if (ProductoIdComboBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Producto Id) está vacío.\n\nPorfavor, Seleccione el Producto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ProductoIdComboBox.IsDropDownOpen = true;
                return;
            }
            if (CantidadTextBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Cantidad) está vacio.\n\nEscriba la cantidad de productos devueltos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                return;
            }

            var filaDetalle = new DevolucionesDetalle
            {
                DevolucionId = this.devoluciones.DevolucionId,
                ProductoId = Convert.ToInt32(ProductoIdComboBox.SelectedValue.ToString()),
                //——————————————————————————————[ Nombre en el ComboBox ]——————————————————————————————
                productos = (Productos)ProductoIdComboBox.SelectedItem,
                //—————————————————————————————————————————————————————————————————————————————————————
                Cantidad = Convert.ToDouble(CantidadTextBox.Text.ToString())
            };
            //——————————————————————————————[ Total]——————————————————————————————
            double cant =  (double.Parse(CantidadTextBox.Text));

            devoluciones.TotalDevoluciones += cant;
            //——————————————————————————————————————————————————————————————————————————
            this.devoluciones.Detalle.Add(filaDetalle);
            Cargar();

            ProductoIdComboBox.SelectedIndex = -1;
            CantidadTextBox.Clear();
        }
        //——————————————————————————————————————————————————————————————[ Remover Fila ]———————————————————————————————————————————————————————————————
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double total = Convert.ToDouble(ProductoIdComboBox.Text);
                if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                    devoluciones.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                    devoluciones.TotalDevoluciones -= total;
                    Cargar();
                }
            }
            catch
            {
                MessageBox.Show("No has seleccionado ninguna Fila\n\nSeleccione la Fila a Remover.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //——————————————————————————————————————————————————————————————[ Nuevo ]———————————————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //——————————————————————————————————————————————————————————————[ Guardar ]———————————————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                //—————————————————————————————————[ Devolución Id ]—————————————————————————————————
                if (DevolucionesIdTextbox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Devolución Id) está vacío.\n\nAsigne un Id al Préstamo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    DevolucionesIdTextbox.Text = "0";
                    DevolucionesIdTextbox.Focus();
                    DevolucionesIdTextbox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Cliente Id ]—————————————————————————————————
                if (ClienteIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Cliente Id) está vacío.\n\nSelecione un Cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ClienteIdComboBox.IsDropDownOpen = true;
                    return;
                }

                var paso = DevolucionesBLL.Guardar(this.devoluciones);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————————————————————[ Eliminar ]———————————————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (DevolucionesBLL.Eliminar(int.Parse(DevolucionesIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————————————————————[ TextChanged ]———————————————————————————————————————————————————————————————
        //——————————————————————————————————————————[ Devolucion Id ]——————————————————————————————————————————
        private void PrestamoIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (DevolucionesIdTextbox.Text.Trim() != string.Empty)
                {
                    int.Parse(DevolucionesIdTextbox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Préstamo Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                DevolucionesIdTextbox.Text = "0";
                DevolucionesIdTextbox.Focus();
                DevolucionesIdTextbox.SelectAll();
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
                MessageBox.Show($"El valor digitado en el campo (Cantidad) no es un número.\n\nPor favor, digite un número de dias valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Text = "0";
                CantidadTextBox.Focus();
                CantidadTextBox.SelectAll();
            }
        }
    }
}