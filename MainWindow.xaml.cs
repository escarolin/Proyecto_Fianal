using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto_Final.UI.Registros;

namespace Proyecto_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  protected override void OnClosed(EventArgs e)
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
        // private void cProyectosMenuItem_Click(object sender, RoutedEventArgs e)
       // {
           // cProyectos cProyectos = new cProyectos();
           // cProyectos.Show();
       // }
    }
}
