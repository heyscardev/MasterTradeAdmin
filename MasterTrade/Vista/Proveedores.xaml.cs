using MasterTrade.Modelo.Enums;
using MasterTrade.Vista.Herramientas;
using Microsoft.Win32;
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
        private Imagenes ima = new Imagenes();
        public Proveedores()
        {
            InitializeComponent();
            _config();

        }
        private void _config()
        {
            pickFNacimento.SelectedDate = DateTime.Now.AddYears(-18);
            pickFNacimento.DisplayDateEnd = DateTime.Now.AddYears(-18);
            pickFNacimento.DisplayDateStart = new DateTime(1900, 01, 01);
            _blank();

        }
        private void _blank()
        {
            pickFNacimento.SelectedDate = DateTime.Now.AddYears(-18);
            tbxIdentificacion.Text = "";
            tbxCorreo.Text = "";
            tbxDireccion.Text = "";
            tbxNombre.Text = "";
            cbxIdentificacion.SelectedIndex = 0;
            tbxTelefono.Text = "";

        }
        private bool camposValidados()
        {
            bool resp = true;
            if (cbxIdentificacion.SelectedItem == null)
            {
                cbxIdentificacion.Background = Brushes.Red;
                resp = false;
            }
           
          
            if (Vaciotbx(tbxCorreo))
            {
                tbxCorreo.Background = Brushes.Green;
            }
            else if (!Herramientas.Validaciones.IsCorreo(tbxCorreo.Text))
            {
                tbxCorreo.Background = Brushes.Red;
                resp = false;
            }

            if (Vaciotbx(tbxIdentificacion))
            {
                resp = false;
            }

            if (Vaciotbx(tbxNombre))
            {
                
                resp = false;
            }
            if (Vaciotbx(tbxDireccion))
            {

                tbxDireccion.Background = Brushes.Green; ;
            }
            if (Vaciotbx(tbxTelefono))
            {
                tbxTelefono.Background = Brushes.Green;
            }
            if (pickFNacimento.SelectedDate.Value.Date.CompareTo(DateTime.Now) > 0 || pickFNacimento.SelectedDate.Value.Date.CompareTo(new DateTime(1900, 01, 01)) < 0)
            {
                pickFNacimento.Background = Brushes.Red;
                resp = false;
            }
            else
            {
                pickFNacimento.Background = Brushes.Green;
            }
            return resp;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!camposValidados()) MessageBox.Show("campo invalidos");
            else MessageBox.Show("campo validos");
        }

        private void btnAddImagen_Click(object sender, RoutedEventArgs e)
        {


            if (ima.openDialog())
                imagen.Source = ima.imagenBitmap;
        }
        private bool Vaciotbx(TextBox t)
        {
            t.Background = Brushes.Green;
            if (t.Text.Length == 0) { t.Background = Brushes.Red; return true; }
            return false;
        }
        private void tbxSoloLetrasn_KeyDown(object sender, KeyEventArgs e) { if (!Validaciones.SoloLetrasTabEnter(e)) e.Handled = true; }
      

        private void tbxSoloNumeros_KeyDown(object sender, KeyEventArgs e) { if (!Validaciones.SoloNumeroTabEnter(e) ) e.Handled = true; }

        private void tbxValidaVacio(object sender, KeyEventArgs e){ Vaciotbx(sender as TextBox); }

        private void tbxValidaCorreo(object sender, KeyEventArgs e)
        {
            TextBox t = sender as TextBox;
            t.Background = Brushes.Green;
            if (!Validaciones.IsCorreo(t.Text)&& t.Text.Length>0) t.Background = Brushes.Red;
           
            
            
        }
    }
}
