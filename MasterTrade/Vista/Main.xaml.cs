using MasterTrade.Modelo.Enums;
using MasterTrade.Vista.Clientes;
using MasterTrade.Vista.Reuitilizable;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace MasterTrade.Vista
{
    
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            //contenedor_ventana.Child = new Registro();
        }
        private void set_lateral_bars(TipoUsuario e)
        {
            switch (e)
            {
                case TipoUsuario.Administrador:

                    break;
            }
        }
        private Button  lateralBarButon(string url , string texto)
        {
           
            Button b = new Button();
            Grid butongrid = new Grid();
            b.Content = texto;
           
            b.Background = Brushes.Transparent;
            return b;
        }
        private void btn_cerrar_ventana_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            App.Current.Shutdown();
            
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //tooltip visibilidad
            ToolTip? tt = (e.Source as ListViewItem).ToolTip as ToolTip;
            if (tt != null)
                if (togle.IsChecked == true )
                    tt.Visibility = Visibility.Collapsed;
                else 
                    tt.Visibility=Visibility.Visible;
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
