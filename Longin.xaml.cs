using System;
using System.Windows;
using System.Windows.Input;
using Proyecto_Final.BLL;
using Proyecto_Final.Entidades;
using Proyecto_Final.DAL;

namespace Proyecto_Final.UI.Longin
{
    public partial class Longin : Window
    {
        Usuarios usuarios = new Usuarios();
        MainWindow MenuPrincipal = new MainWindow();
        public Longin()
        {
            InitializeComponent();
        }
        //———————————————————————————————————————————————————[ CERRAR - Al ingresar usuario o contraseña incorrecta]———————————————————————————————————————————————————
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        //———————————————————————————————————————————————————[ CANCELAR ]———————————————————————————————————————————————————
        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //———————————————————————————————————————————————————[ INGRESAR ]———————————————————————————————————————————————————
        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuariosBLL.Autenticar(UsuarioNTextBox.Text, ClavePasswordBox.Password);

            //—————————————————————————————————[ UsurioN Vacio]—————————————————————————————————
            if (UsuarioNTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Nombre Usuario) está vacío.\n\nPor favor, escriba su nombre de usuario.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                UsuarioNTextBox.Clear();
                UsuarioNTextBox.Focus();
                return;
            }

            if (paso)
            {
                this.Hide();
                MenuPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Nombre de Usuario o Contraseña incorrectos.", "Precaución", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClavePasswordBox.Clear();
                UsuarioNTextBox.Focus();
            }
        }
        //———————————————————————————————————————————————————[ NOMBRE USUARIO - ENTER ]———————————————————————————————————————————————————
        private void UsuarioNTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ClavePasswordBox.Focus();
            }
        }
        //———————————————————————————————————————————————————[CONTRASEÑA - ENTER ]———————————————————————————————————————————————————
        private void ClavePasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                bool paso = UsuariosBLL.Autenticar(UsuarioNTextBox.Text, ClavePasswordBox.Password);

                if (paso)
                {
                    this.Hide();
                    MenuPrincipal.Show();
                }
                else
                {
                    MessageBox.Show("Nombre de Usuario o Contraseña incorrectos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    ClavePasswordBox.Clear();
                    UsuarioNTextBox.Focus();
                }
            }
        }
    }
}
