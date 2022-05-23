
using Microsoft.Win32;
using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MasterTrade.Modelo.Entidades;
using MasterTrade.Vista.Herramientas;

namespace MasterTrade.Vista.Reutilizable
{
    /// <summary>
    /// Lógica de interacción para InputDataCliente.xaml
    /// </summary>
    public partial class InputDataEntidad : UserControl
    {
        private static InputDataEntidad _instance;
        private bool Modify = false;
        private Cliente? cliente = null;
        private Proveedor? proveedor = null;
        private InputDataEntidad()
        {

            InitializeComponent();

        }
        public static InputDataEntidad getInstance()
        {
            if (_instance == null)
                _instance = new InputDataEntidad();
            return _instance;
        }
        public static InputDataEntidad getInstance(Cliente cliente)
        {
            var input = InputDataEntidad.getInstance();
            input.proveedor = null;
            input.cliente = cliente;
            if (cliente.Id == 0)
            {
                input.Modify = true;
                input.tb_razon_social.Text = cliente.RazonSocial;
                input.combo_document.Items.Contains(cliente.TipoIdentificacion);
               
                input.tb_direccion.Text = cliente.Direccion;
                input.tb_correo.Text = cliente.Correo;
                input.imagen.Source = cliente.Imagen == null ?
                    (new BitmapImage(new Uri("/Vista/Recurosos/Iconos/IconoImageAdd.png", UriKind.Relative))) :
                    new BitmapImage(new Uri(cliente.Imagen, UriKind.Absolute));
            }
            return input;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Guardar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Cancelar_Click(object sender, RoutedEventArgs e)
        {
            getInstance().cliente = null;
            getInstance().proveedor = null;
            getInstance().Modify = false;
            var rect = sender as Button;
            FrameworkElement framework = rect;
            while (framework != null && (framework as Window) == null && framework.Parent != null)
            {
                framework = framework.Parent as FrameworkElement;
            }
            if (framework is Window window)
            {
                window.Close();
            }
        }

        private void Button_CargarImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files|*.jpg;*.jpeg;*.png;";
            file.Title = "IMAGEN DE USUARIO";

            if (file.ShowDialog() == true)
            {
                imagen.Source = (new BitmapImage(new Uri(file.FileName, UriKind.Absolute)));
            }
        }

        private void Text_Box_SoloLetras(object sender, KeyEventArgs e)
        {
            Validaciones.SoloLetrasTabEnter(e);
        }
        private void Text_Box_Solo_Numeros(object sender, KeyEventArgs e)
        {
         Validaciones.SoloNumeroTabEnter(e);
        }
        private void Text_Box_Solo_Numeros_telefono(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.OemPlus) Validaciones.SoloNumeroTabEnter(e);
        }

        private void Text_Box_Is_Correo(object sender, TextChangedEventArgs e)
        {
            TextBox obj = sender as TextBox;
            if (!Validaciones.IsCorreo(obj.Text))
                obj.Background = Brushes.Red;
            else
                obj.Background = Brushes.White;
        }

        private void imagen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Files|*.jpg;*.jpeg;*.png;";
            file.Title = "IMAGEN DE USUARIO";

            if (file.ShowDialog() == true)
            {
                imagen.Source = (new BitmapImage(new Uri(file.FileName, UriKind.Absolute)));
            }
        }
    }
}
