using System;
using System.Windows;
using Proyecto_Final.UI.Registros;
using Proyecto_Final.UI.Consultas;

namespace Proyecto_Final
{
    public partial class MainWindow : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void rUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show();
        }
        private void rClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }
        private void rProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProductos rProductos = new rProductos();
            rProductos.Show();
        }
        private void rDevolucionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rDevoluciones rDevoluciones = new rDevoluciones();
            rDevoluciones.Show();
        }

        private void rVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVentas rVentas = new rVentas();
            rVentas.Show();
        }
        private void rEntradaProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEntradaProductos rUsuarios = new rEntradaProductos();
            rUsuarios.Show();
        }

        private void cUsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();
        }

        private void cClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show();
        }

        private void cDevolucionesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cDevoluciones cDevoluciones = new cDevoluciones();
            cDevoluciones.Show();
        }

        private void cProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cProductos cProductos = new cProductos();
            cProductos.Show();
        }

        private void cEntradaProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEntradaProductos cEntradaProductos = new cEntradaProductos();
            cEntradaProductos.Show();
        }

        private void cVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVentas cVentas = new cVentas();
            cVentas.Show();
        }
    }
}
