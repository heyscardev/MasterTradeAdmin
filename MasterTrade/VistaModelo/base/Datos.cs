using MasterTrade.Modelo.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTrade.VistaModelo
{
    public class Datos 
    {
        private static BaseDatos _Instance;
        //constructor privado evita usar  otras instancias
        private Datos(){}
        public static BaseDatos GetBaseDatos()
        {
            //solo devolvera una instancia en la ejecucion del programa
            if(_Instance == null) _Instance = new BaseDatos();
            return _Instance;
        }
    }
}
