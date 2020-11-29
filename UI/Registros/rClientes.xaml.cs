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
using Proyecto_Final.DAL;


namespace Proyecto_Final.UI.Registros
{
    /// <summary>
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        private Clientes clientes = new Clientes();
        public rClientes()
        {
            InitializeComponent();

            this.DataContext = clientes;
        }

        //——————————————————————————————————————————————————————————————[ Cargar ]———————————————————————————————————————————————————————————————
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }
        //——————————————————————————————————————————————————————————————[ Limpiar ]——————————————————————————————————————————————————————————————
        private void Limpiar()
        {
            this.clientes = new Clientes();
            this.DataContext = clientes;
        }
        //——————————————————————————————————————————————————————————————[ Validar ]——————————————————————————————————————————————————————————————
        private bool Validar()
        {
            bool Validado = true;
            if (ClienteIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida\n\nNo se pudo validar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }
        //——————————————————————————————————————————————————————————————[ Buscar ]———————————————————————————————————————————————————————————————
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Clientes encontrado = ClientesBLL.Buscar(int.Parse((ClienteIdTextBox.Text)));

            if (encontrado != null)
            {
                this.clientes = encontrado;
                Cargar();
            }
            else
            {
                this.clientes = new Clientes();
                this.DataContext = this.clientes;

                MessageBox.Show($"Este Contacto no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

                Limpiar();
                ClienteIdTextBox.SelectAll();
                ClienteIdTextBox.Focus();
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
                //—————————————————————————————————[ Contacto Id ]—————————————————————————————————
                if (ClienteIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Contacto Id) está vacío.\n\nPorfavor, Asigne un Id al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ClienteIdTextBox.Text = "0";
                    ClienteIdTextBox.Focus();
                    ClienteIdTextBox.SelectAll();
                    return;
                }

                //—————————————————————————————————[ NombreCompleto ]—————————————————————————————————
                if (NombresTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Completo) está vacío.\n\nPorfavor, Asigne un Nombre al Contacto.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombresTextBox.Clear();
                    NombresTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Telefono ]—————————————————————————————————
                if (TelefonoTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Teléfono) está vacío.\n\nAsigne un Teléfono al Estudiante.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TelefonoTextBox.Text = "0";
                    TelefonoTextBox.Focus();
                    TelefonoTextBox.SelectAll();
                    return;
                }
                if (TelefonoTextBox.Text.Length != 10)
                {
                    MessageBox.Show($"El Teféfono ({TelefonoTextBox.Text}) no es válido.\n\nEl Teléfono debe tener 10 dígitos (0-9).", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    TelefonoTextBox.Focus();
                    return;
                }
                //———————————————————————————————————————————————————————[ VALIDAR SI ESTA VACIO - FIN ]———————————————————————————————————————————————————————
                var paso = ClientesBLL.Guardar(clientes);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("El Registro se pudo guardar satisfactoriamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("El Registro no se pudo guardar :(", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //——————————————————————————————————————————————————————————————[ Eliminar ]———————————————————————————————————————————————————————————————
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ClientesBLL.Eliminar(int.Parse(ClienteIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //—————————————————————————————————————————————————————————————[ TEXT CHANGED ]—————————————————————————————————————————————————————————————

        //—————————————————————————————————[ Contacto Id ]—————————————————————————————————
        private void ClienteIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ClienteIdTextBox.Text.Trim() != string.Empty)
                {
                    int.Parse(ClienteIdTextBox.Text);
                }
            }
            catch
            {
                MessageBox.Show($"El valor digitado en el campo (Contacto Id) debe ser un número.\n\nPor favor, digite un número valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClienteIdTextBox.Text = "0";
                ClienteIdTextBox.Focus();
                ClienteIdTextBox.SelectAll();
            }
        }
        //—————————————————————————————————[ Telefono ]—————————————————————————————————
        private void TelefonoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TelefonoTextBox.Text.Trim() != string.Empty)
                {
                    long.Parse(TelefonoTextBox.Text);
                }

                if (TelefonoTextBox.Text.Length != 10)
                {
                    TelefonoTextBox.Foreground = Brushes.Red;
                }
                else
                {
                    TelefonoTextBox.Foreground = Brushes.Green;
                }
            }
            catch
            {
                MessageBox.Show("El valor digitado en el campo (Teléfono) no es un número.\n\nPor favor, digite un número.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Text = "0";
                TelefonoTextBox.Focus();
                TelefonoTextBox.SelectAll();
            }
        }

        
    }
}
