
using MasterTrade.Modelo.Contexto;

namespace MasterTrade.Controlador.GlobalLogica
{
    public class Datos
    {
        private static BaseDatos _instance = new BaseDatos();
        private Datos()
        {
        }
        public static BaseDatos getBaseDatos()
        {
            return _instance;
        }
    }
}
