
using MasterTrade.Controlador.GlobalLogica;
using MasterTrade.Vista.Reutilizable;
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
            datos.Child = InputDataEntidad.getInstance();
            actualizar_datos();
        }
        private void actualizar_datos()
        {
            
          
            tabla.ItemsSource = Datos.getBaseDatos().Clientes.ToList();
            
        }
    }
}
