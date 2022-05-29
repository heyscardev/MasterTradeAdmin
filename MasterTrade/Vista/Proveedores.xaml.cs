
using MasterTrade.Modelo.Entidades;
using MasterTrade.Vista.Herramientas.validaciones;
using MasterTrade.VistaModelo;
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
    /// Lógica de interacción para Proveedores.xaml
    /// </summary>
    public partial class Proveedores : UserControl
    {
        private ValidaFormulario vf;
        public Proveedores()
        {
            InitializeComponent();
            _config();


        }
        private void _config()
        {
            vf = new ValidaFormulario(Brushes.Red, Brushes.Green);
            vf.addInput(txtCorreo, "").email().max("200");
            vf.addInput(txtDocumento, "").requerido().soloNumeros().max("20");
            vf.addInput(txtNombre, "").requerido().soloLetras().max("80");
            vf.addInput(txtDireccion, "").max("250");
            vf.addInput(txtTelefono, "").phone().max("20");
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Set_Botones("INICIO");
            Set_DatePicker();
            Set_TextBoxes(false);
            gridElementos.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            /*
             * 
            Clear_Campos();
            Set_Botones("INICIO");
            Set_TextBoxes(false);
            gridElementos.Visibility = Visibility.Collapsed;
            */
            if (vf.formularioisValido()) MessageBox.Show("todo bien");
            else MessageBox.Show("algo mal");
         
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

        public void Set_DatePicker()
        {
            dtNacimiento.SelectedDate = System.DateTime.Today;
        }

        public void Clear_Campos()
        {
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            dtNacimiento.SelectedDate = System.DateTime.Today;
        }

        public void Set_TextBoxes(bool estado)
        {
            txtDocumento.IsEnabled = estado;
            txtNombre.IsEnabled = estado;
            txtDireccion.IsEnabled = estado;
            txtTelefono.IsEnabled = estado;
            txtCorreo.IsEnabled = estado;
            dtNacimiento.IsEnabled = estado;
            comboDocumento.IsEnabled = estado;
            comboTelefono.IsEnabled = estado;
        }

        private void bttnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }
        //eventos de validacion


    }
}
