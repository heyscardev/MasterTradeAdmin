using MasterTrade.Clases;
using MasterTrade.Vista;

namespace MasterTrade.VistaModelo
{
    class VistaModelo_Registro
    {
        public ComandoBotones BuscarUsuario{ get; set; }
        public VistaModelo_Registro()
        {
            BuscarUsuario = new ComandoBotones(this);
        }
        
        public void OnExcecute()
        {
            
        }
    }
}
