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
using System.Windows.Shapes;

namespace MasterTrade.Vista
{
    /// <summary>
    /// Lógica de interacción para Ejemplo_Buscar.xaml
    /// </summary>
    public partial class Ejemplo_Buscar : Window
    {
        public Ejemplo_Buscar()
        {
            InitializeComponent();            
        }

        private void bttnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
