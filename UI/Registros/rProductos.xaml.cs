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
using Proyecto_Final.BLL;
using Proyecto_Final.Entidades;

namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        private Productos productos = new Productos();
        public rProductos()
        {
            InitializeComponent();
            this.DataContext = productos;
            //—————————————————————————————————————[ ComboBox UsuarioId ]—————————————————————————————————————
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";
            //—————————————————————————————————————[ ComboBox EditorialId ]—————————————————————————————————————
            MarcaIdComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcaIdComboBox.SelectedValuePath = "EditorialId";
            MarcaIdComboBox.DisplayMemberPath = "NombreMarca";
        }
        //——————————————————————————————————————————————————————————————[ Cargar ]———————————————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = productos;
        }
        //——————————————————————————————————————————————————————————————[ Limpiar ]——————————————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.productos = new Productos();
            this.DataContext = productos;
        }
        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (ProductoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Productos encontrado = ProductosBLL.Buscar(Utiidades.ToInt(ProductoIdTextBox.Text));

            if (encontrado != null)
            {
                this.productos = encontrado;
                Cargar();
            }
            else
            {
                this.productos = new Productos();
                this.DataContext = this.productos;
                MessageBox.Show($"Este Libro no fue encontrado.\n\nAsegúrese que existe o cree una nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                ProductoIdTextBox.SelectAll();
                ProductoIdTextBox.Focus();
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

                //———————————————————————————————————————————————————————[ VALIDAR SI ESTA VACIO ]———————————————————————————————————————————————————————
                //—————————————————————————————————[ Libro Id ]—————————————————————————————————
                if (ProductoIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Libro Id) está vacío.\n\nAsigne un Id al Libro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ProductoIdTextBox.Text = "0";
                    ProductoIdTextBox.Focus();
                    ProductoIdTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Usuario Id ]—————————————————————————————————
                if (UsuarioIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nPorfavor, Seleccione su Nombre de Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdComboBox.IsDropDownOpen = true;
                    return;
                }
                //—————————————————————————————————[ Titulo ]—————————————————————————————————
                if (NombrePTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Titulo) está vacío.\n\nEscriba un de Titulo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombrePTextBox.Clear();
                    NombrePTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Editorial Id ]—————————————————————————————————
                if (MarcaIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Editorial Id) está vacío.\n\nPorfavor, Seleccione la Editorial del libro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    MarcaIdComboBox.IsDropDownOpen = true;
                    return;
                }
                //—————————————————————————————————[ ISBN ]—————————————————————————————————
                if (PrecioTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (ISBN) está vacío.\n\nEscriba un de ISBN.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PrecioTextBox.Clear();
                    PrecioTextBox.Focus();
                    return;
                }
                if (PrecioTextBox.Text.Length != 10 && PrecioTextBox.Text.Length != 13)
                {
                    MessageBox.Show($"El ISBN ({PrecioTextBox.Text}) no es válido.\n\nEl ISBN debe tener 10 o 13 dígitos (0-9).", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PrecioTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Fecha ]—————————————————————————————————
                if (FechaPDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show($"El Campo (Fecha) está vacío.\n\nSeleccione una fecha.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaPDatePicker.Focus();
                    return;
                }
                //—————————————————————————————————[ Existencia ]—————————————————————————————————
                if (ExistenciaTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Existencia) está vacío.\n\nEscriba la existencia actual del Libro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ExistenciaTextBox.Text = "0";
                    ExistenciaTextBox.Focus();
                    ExistenciaTextBox.SelectAll();
                    return;
                }
                //———————————————————————————————————————————————————————[ VALIDAR SI ESTA VACIO - FIN ]———————————————————————————————————————————————————————
                var paso = ProductosBLL.Guardar(productos);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————————————————————[ Eliminar ]———————————————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ProductosBLL.Eliminar(Utiidades.ToInt(ProductoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //—————————————————————————————————————————————————————————————[ TEXT CHANGED ]—————————————————————————————————————————————————————————————

        //——————————————————————————————————————————[ LibroId ]——————————————————————————————————————————
        private void LibroIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ProductoIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(ProductoIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Libro Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ProductoIdTextBox.Text = "0";
                ProductoIdTextBox.Focus();
                ProductoIdTextBox.SelectAll();
            }
        }
        //——————————————————————————————————————————[ ISBN ]——————————————————————————————————————————
        private void PrecioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (PrecioTextBox.Text.Trim() != string.Empty)
                {
                    long.Parse(PrecioTextBox.Text);
                }

                if (PrecioTextBox.Text.Length == 10 || PrecioTextBox.Text.Length == 13)
                {
                    PrecioTextBox.Foreground = Brushes.Black;
                }
                else
                {
                    PrecioTextBox.Foreground = Brushes.Red;
                }
            }
            catch
            {
                MessageBox.Show("El valor digitado en el campo (ISBN) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioTextBox.Text = "0";
                PrecioTextBox.Focus();
                PrecioTextBox.SelectAll();
            }
        }
        //——————————————————————————————————————————[ Existencia ]——————————————————————————————————————————
        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double Existencia;

            if (double.TryParse(ExistenciaTextBox.Text, out Existencia))
            {
                if (Existencia < 0)
                {
                    ExistenciaTextBox.Foreground = Brushes.Red;
                }
                if (Existencia == 0)
                {
                    ExistenciaTextBox.Foreground = Brushes.Black;
                }
                else if (Existencia > 0)
                {
                    ExistenciaTextBox.Foreground = Brushes.Green;
                }
            }
        }
    }
}
