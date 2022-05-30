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

namespace MasterTrade.Vista
{
    /// <summary>
    /// Lógica de interacción para Sesion_iniciada.xaml
    /// </summary>
    public partial class Sesion_iniciada : UserControl
    {
        public Sesion_iniciada()
        {
            InitializeComponent();
        }

        private void btn_cerrar_ventana_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();

        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //tooltip visibilidad
            ToolTip? tt = (e.Source as ListViewItem).ToolTip as ToolTip;
            if (tt != null)
                if (togle.IsChecked == true)
                    tt.Visibility = Visibility.Collapsed;
                else
                    tt.Visibility = Visibility.Visible;
        }

        private void togle_Checked(object sender, RoutedEventArgs e)
        {
            contenedor_ventana.Opacity = 0.3;

        }

        private void togle_Unchecked(object sender, RoutedEventArgs e)
        {
            contenedor_ventana.Opacity = 1;
        }
    }
}
