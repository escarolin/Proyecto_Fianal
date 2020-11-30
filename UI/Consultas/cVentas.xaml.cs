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

namespace Proyecto_Final.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ventas> listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = VentasBLL.GetList(p => p.VentaId== Utiidades.ToInt(CriterioTextBox.Text));
                        break;

                        //case 1:
                        //    listado = VentasBLL.GetList(p => p..Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        //    break;
                }
            }
            else
            {
                listado = VentasBLL.GetList(c => true);
            }
            if (DesdeDatePicker.SelectedDate != null)
                listado = (List<Ventas>)VentasBLL.GetList(p => p.FechaF.Date >= DesdeDatePicker.SelectedDate);
            if (HastaDatePicker.SelectedDate != null)
                listado = (List<Ventas>)VentasBLL.GetList(p => p.FechaF.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
