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
    /// Lógica de interacción para Vender.xaml
    /// </summary>
    public partial class Vender : UserControl
    {
        public Vender()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Hide_ColumnaComprar();
            Set_TextBoxes(false);
            txtCantidad.Text = "0";
        }

        private void bttnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Ejemplo_Buscar ventanaBuscar = new Ejemplo_Buscar();
            ventanaBuscar.ShowDialog();
        }

        private void bttnAtras_Click(object sender, RoutedEventArgs e)
        {
            Hide_ColumnaComprar();
            Clear_Campos();
            Set_TextBoxes(false);
        }

        private void bttnAgnadir_Click(object sender, RoutedEventArgs e)
        {
            Show_ColumnaComprar();
            Set_TextBoxes(true);
            txtCantidad.Text = "1";
        }
        public void Hide_ColumnaComprar()
        {
            stackCarrito.Visibility = Visibility.Collapsed;
            stackDetalles.Visibility = Visibility.Collapsed;
            bttnConfirmar.Visibility = Visibility.Collapsed;
        }
        public void Show_ColumnaComprar()
        {
            stackCarrito.Visibility = Visibility.Visible;
            stackDetalles.Visibility = Visibility.Visible;
            bttnConfirmar.Visibility = Visibility.Visible;
        }
        public void Clear_Campos()
        {
            txtNombre.Text = "";
            txtCodigoBarras.Text = "";
            txtCantidad.Text = "0";
        }

        public void Set_TextBoxes(bool estado)
        {
            txtNombre.IsEnabled = estado;
            txtCodigoBarras.IsEnabled = estado;
            txtCantidad.IsEnabled = estado;
        }
    }
}
