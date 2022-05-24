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
    /// Lógica de interacción para Comprar.xaml
    /// </summary>
    public partial class Comprar : UserControl
    {
        public Comprar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {
            txtCantidad.Text = "0";
            Hide_ColumnaComprar();
            Set_TextBoxes(false);
        }

        private void bttnAtras_Click(object sender, RoutedEventArgs e)
        {
            Hide_ColumnaComprar();
            Set_TextBoxes(false);
            Clear_Campos();
        }

        private void bttnAgnadir_Click(object sender, RoutedEventArgs e)
        {
            Show_ColumnaComprar();
            Set_TextBoxes(true);
            txtCantidad.Text = "1";
        }

        private void bttnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Ejemplo_Buscar ventanaBuscar = new Ejemplo_Buscar();
            ventanaBuscar.ShowDialog();
        }

        public void Hide_ColumnaComprar()
        {
            stackCarrito.Visibility = Visibility.Collapsed;
            gridDetalles.Visibility = Visibility.Collapsed;
            labelTotal.Visibility = Visibility.Collapsed;
            bttnConfirmar.Visibility = Visibility.Collapsed;
        }

        public void Show_ColumnaComprar()
        {
            stackCarrito.Visibility = Visibility.Visible;
            gridDetalles.Visibility = Visibility.Visible;
            labelTotal.Visibility = Visibility.Visible;
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
