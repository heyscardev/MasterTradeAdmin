using MasterTrade.Modelo.Entidades;
using System.Linq;

namespace MasterTrade.Controlador.GlobalLogica
{
    public class Sesion
    {
        private static Sesion? _instance;
        public Usuario Usuario { get; set; } 
        private Sesion(Usuario us)
        {
            Usuario = us;
        }
        public static Sesion getSesion()
        {
            return _instance;
        }

        public static Sesion iniciarSesion(string nombreUsuario,string Contraseña)
        {
            if (_instance != null) _instance.closeSesion();
                var busqueda = Datos.getBaseDatos()
               .Usuarios
               .Where(u =>
               u.NombreUsuario.ToLower() == nombreUsuario.ToLower() &&
               u.Contraseña == u.Contraseña).FirstOrDefault();
                if (busqueda != null)
                {
                    _instance = new Sesion(busqueda);
                }
            return _instance;
        }

        public void closeSesion()
        {
            _instance = null;
        }

    }
}
