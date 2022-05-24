using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MasterTrade.Vista
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Label_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dtTicker;
            dt.Start();
        }

        private void dtTicker(object? sender, EventArgs e)
        {
            Reloj.Content = DateTime.Now.ToLongTimeString();
            String contenido = DateTime.Now.ToLongDateString();
            Fecha.Content = contenido.ToUpper();
        }
    }
}
