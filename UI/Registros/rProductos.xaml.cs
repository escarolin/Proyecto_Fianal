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

            //—————————————————————————————————————[ ComboBox MarcaId ]—————————————————————————————————————
            MarcaIdComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcaIdComboBox.SelectedValuePath = "MarcaId";
            MarcaIdComboBox.DisplayMemberPath = "NombreMarca";
            //—————————————————————————————————————[ ComboBox UsuarioId ]—————————————————————————————————————
            UsuarioIdComboBox.ItemsSource = UsuariosBLL.GetUsuarios();
            UsuarioIdComboBox.SelectedValuePath = "UsuarioId";
            UsuarioIdComboBox.DisplayMemberPath = "NombreUsuario";


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
                MessageBox.Show($"Este Producto no fue encontrado.\n\nAsegúrese que existe o cree una nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                //—————————————————————————————————[ Producto Id ]—————————————————————————————————
                if (ProductoIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Producto Id) está vacío.\n\nAsigne un Id al Libro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ProductoIdTextBox.Text = "0";
                    ProductoIdTextBox.Focus();
                    ProductoIdTextBox.SelectAll();
                    return;
                }

                //—————————————————————————————————[ Nombre ]—————————————————————————————————
                if (NombrePTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre producto) está vacío.\n\nEscriba un Nombre.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombrePTextBox.Clear();
                    NombrePTextBox.Focus();
                    return;
                }

                //—————————————————————————————————[ Marca Id ]—————————————————————————————————
                if (MarcaIdComboBox.Text == string.Empty)
                {
                    MessageBox.Show("El Campo (Marca Id) está vacío.\n\nPorfavor, Seleccione una marca .", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    MarcaIdComboBox.IsDropDownOpen = true;
                    return;
                }

                //—————————————————————————————————[ Precio ]—————————————————————————————————
                if (PrecioTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Precio) está vacío.\n\nEscriba un de Precio.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    PrecioTextBox.Clear();
                    PrecioTextBox.Focus();
                    return;
                }

                //—————————————————————————————————[ ITBIS ]—————————————————————————————————
                if (ItebisTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (ITBIS) está vacío.\n\nEscriba un Itbis.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ItebisTextBox.Focus();
                    ItebisTextBox.SelectAll();
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
                if (DescripcionTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Descripcion) está vacío.\n\nRealice una despcricion  .", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);


                    DescripcionTextBox.Focus();
                    DescripcionTextBox.SelectAll();
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
                    MessageBox.Show("Producto Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //—————————————————————————————————————————————————————————————[ TEXT CHANGED ]—————————————————————————————————————————————————————————————

        //——————————————————————————————————————————[ ProductoId ]——————————————————————————————————————————
        private void ProductoIdTextbox_TextChanged(object sender, TextChangedEventArgs e)
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
                MessageBox.Show($"El valor digitado en el campo (Producto Id) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ProductoIdTextBox.Text = "0";
                ProductoIdTextBox.Focus();
                ProductoIdTextBox.SelectAll();
            }
        }
        //——————————————————————————————————————————[ Precio ]——————————————————————————————————————————
        private void PrecioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (PrecioTextBox.Text.Trim() != string.Empty)
                {
                    double.Parse(PrecioTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Precio) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioTextBox.Text = "0";
                PrecioTextBox.Focus();
                PrecioTextBox.SelectAll();
            }
        }

        //——————————————————————————————————————————[ Costo ]——————————————————————————————————————————
        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (PrecioTextBox.Text == string.Empty || CostoTextBox.Text == string.Empty)
                {
                    PrecioTextBox.Text = "0";
                    CostoTextBox.Text = "0";
                }
                else
                {
                    double precio = Convert.ToDouble(PrecioTextBox.Text.Trim());
                    double costo = Convert.ToDouble(CostoTextBox.Text.Trim());
                    double ganancia = (precio - costo);

                    GanaciaTextBox.Text = (Convert.ToDouble(Math.Round(ganancia, 2))).ToString();
                    productos.Ganacia = Convert.ToDouble(GanaciaTextBox.Text);

                }

                if (CostoTextBox.Text.Trim() != string.Empty)
                {
                    double.Parse(CostoTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Costo) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CostoTextBox.Text = "0";
                CostoTextBox.Focus();
                CostoTextBox.SelectAll();
            }
        }
        //——————————————————————————————————————————[ ITBIS ]——————————————————————————————————————————
        private void ItebisTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ItebisTextBox.Text.Trim() != string.Empty)
                {
                    double.Parse(ItebisTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (ITBIS) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ItebisTextBox.Text = "0";
                ItebisTextBox.Focus();
                ItebisTextBox.SelectAll();
            }
        }
    }
}