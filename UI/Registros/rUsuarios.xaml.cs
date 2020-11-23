using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Proyecto_Final.Entidades;
using Proyecto_Final.BLL;

namespace Proyecto_Final.UI.Registros
{
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();

        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = usuarios;
            ClavePasswordBox.Password = string.Empty;
            ConfimarClavePasswordBox.Password = string.Empty;
        }

        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            this.DataContext = usuarios;
            ClavePasswordBox.Password = string.Empty;
            ConfimarClavePasswordBox.Password = string.Empty;
        }

        private bool Validar()
        {
            bool Validado = true;
            if (UsuarioIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios encontrado = UsuariosBLL.Buscar(int.Parse(UsuarioIdTextBox.Text));

            if (encontrado != null)
            {
                this.usuarios = encontrado;
                Cargar();
            }
            else
            {
                this.usuarios = new Usuarios();
                this.DataContext = this.usuarios;
                MessageBox.Show($"Este Usuario no fue encontrado.\n\nAsegúrese que existe o cree uno nuevo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                UsuarioIdTextBox.SelectAll();
                UsuarioIdTextBox.Focus();
            }
            if (UsuarioIdTextBox.Text == "1")
            {
                EliminarButton.IsEnabled = false;
                GuardarButton.IsEnabled = false;
            }
            else
            {
                EliminarButton.IsEnabled = true;
                GuardarButton.IsEnabled = true;
            }
        }
        //——————————————————————————————————————————————————————————————[ Nuevo ]———————————————————————————————————————————————————————————————
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            EliminarButton.IsEnabled = true;
            GuardarButton.IsEnabled = true;
        }
        //——————————————————————————————————————————————————————————————[ Guardar ]———————————————————————————————————————————————————————————————
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                //———————————————————————————————————————————————————————[ VALIDAR TEXTBOX ]———————————————————————————————————————————————————————
                //—————————————————————————————————[ Usuario Id ]—————————————————————————————————
                if (UsuarioIdTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Usuario Id) está vacío.\n\nAsigne un Id al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioIdTextBox.Text = "0";
                    UsuarioIdTextBox.Focus();
                    UsuarioIdTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Nombres ]—————————————————————————————————
                if (NombresTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombres) está vacío.\n\nEscriba sus Nombres.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    NombresTextBox.Clear();
                    NombresTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Apellidos ]—————————————————————————————————
                if (ApellidosTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Apellidos) está vacío.\n\nEscriba sus Apellidos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ApellidosTextBox.Clear();
                    ApellidosTextBox.Focus();
                    return;
                }
                //—————————————————————————————————[ Fecha Creación ]—————————————————————————————————
                if (FechaDatePicker.Text.Trim() == string.Empty)
                {
                    MessageBox.Show($"El Campo (Fecha Creación) está vacío.\n\nSeleccione una fecha.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    FechaDatePicker.Focus();
                    return;
                }
                //—————————————————————————————————[ Nombre Usuario ]—————————————————————————————————
                if (UsuarioNTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Usuario) está vacío.\n\nAsigne un Nombre al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioNTextBox.Focus();
                    UsuarioNTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Nombre Usuario ]—————————————————————————————————
                if (UsuarioNTextBox.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("El Campo (Nombre Usuario) está vacío.\n\nAsigne un Nombre al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UsuarioNTextBox.Focus();
                    UsuarioNTextBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Contraseña ]—————————————————————————————————
                if (ClavePasswordBox.Password == string.Empty)
                {
                    MessageBox.Show("El Campo (Contraseña) está vacío.\n\nAsigne una Contraseña al Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ClavePasswordBox.Focus();
                    ClavePasswordBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Confirmar Contraseña ]—————————————————————————————————
                if (ConfimarClavePasswordBox.Password == string.Empty)
                {
                    MessageBox.Show("El Campo (Confirmar Contraseña) está vacío.\n\nConfirme la Contraseña del Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ConfimarClavePasswordBox.Focus();
                    ConfimarClavePasswordBox.SelectAll();
                    return;
                }
                //—————————————————————————————————[ Validar Contraseñas ]—————————————————————————————————
                if (ConfimarClavePasswordBox.Password != ClavePasswordBox.Password)
                {
                    MessageBox.Show("Las Contraseñas escritas no coinciden", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ClavePasswordBox.Clear();
                    ConfimarClavePasswordBox.Clear();
                    ClavePasswordBox.Focus();
                    return;
                }

                var paso = UsuariosBLL.Guardar(usuarios);
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
            //—————————————————————————————————[ Evitar que se borre el Usuario Admin Id #1 ]—————————————————————————————————
            if (UsuarioIdTextBox.Text == "1")
            {
                MessageBox.Show("No se pudo eliminar este Usuario.\n\nNo puede eliminar este Usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                UsuarioIdTextBox.Focus();
                UsuarioIdTextBox.SelectAll();
                return;
            }

            if (UsuariosBLL.Eliminar(int.Parse(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar el registro", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}