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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : UserControl
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Set_Botones("INICIO");
            Set_TextBoxes(false);
            gridElementos.Visibility = Visibility.Collapsed;
        }

        private void bttnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Ejemplo_Buscar ventanaBuscar = new Ejemplo_Buscar();
            ventanaBuscar.ShowDialog();
        }

        private void bttnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Set_Botones("AGREGAR");
            Set_TextBoxes(true);
            gridElementos.Visibility = Visibility.Visible;
            bttnRegistros.Visibility = Visibility.Collapsed;
        }

        private void bttnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Clear_Campos();
            Set_Botones("INICIO");
            Set_TextBoxes(false);
            gridElementos.Visibility = Visibility.Collapsed;
        }

        public void Set_Botones(string comando)
        {
            switch (comando)
            {
                case "INICIO":
                    bttnBuscar.IsEnabled = true;
                    bttnAgregar.IsEnabled = true;
                    bttnCancelar.IsEnabled = false;
                    bttnGuardar.IsEnabled = false;
                    bttnActualizar.IsEnabled = false;
                    bttnEliminar.IsEnabled = false;
                    break;

                case "AGREGAR":
                    bttnBuscar.IsEnabled = false;
                    bttnAgregar.IsEnabled = false;
                    bttnCancelar.IsEnabled = true;
                    bttnGuardar.IsEnabled = true;
                    bttnActualizar.IsEnabled = false;
                    bttnEliminar.IsEnabled = false;
                    break;
            }
        }

        public void Set_TextBoxes(bool estado)
        {
            txtCodigo.IsEnabled = estado;
            txtNombre.IsEnabled = estado;
            txtCodigoBarras.IsEnabled = estado;
            txtProveedor.IsEnabled = estado;
            txtStockMin.IsEnabled = estado;
            txtStockMax.IsEnabled = estado;
            txtCosto.IsEnabled = estado;
        }

        public void Clear_Campos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCodigoBarras.Text = "";
            txtProveedor.Text = "";
            txtStockMin.Text = "";
            txtStockMax.Text = "";
            txtCosto.Text = "";
        }
    }
}
