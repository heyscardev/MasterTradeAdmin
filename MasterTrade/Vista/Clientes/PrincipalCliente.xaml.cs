
using MasterTrade.Controlador.GlobalLogica;

using System.Linq;

using System.Windows.Controls;


namespace MasterTrade.Vista.Clientes
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class PrincipalCliente : UserControl
    {
        public PrincipalCliente()
        {
            InitializeComponent();
          
            actualizar_datos();
        }
        private void actualizar_datos()
        {
            
          
            tabla.ItemsSource = Datos.getBaseDatos().Clientes.ToList();
            
        }
    }
}
