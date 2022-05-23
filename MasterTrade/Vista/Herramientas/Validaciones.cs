using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterTrade.Vista.Herramientas
{
    public class Validaciones
    {
        public static bool SoloLetrasTabEnter(KeyEventArgs e)
        { 
            if (!(e.Key >= Key.A && e.Key <= Key.Z) && e.Key != Key.Tab && e.Key != Key.Enter && e.Key != Key.Back)
            {
                Console.Beep();
                return false;
            }
            return true;
        }
        public static bool SoloNumeroTabEnter(KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9
                || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                && e.Key != Key.Tab 
                && e.Key != Key.Enter
                && e.Key != Key.Back
                )
            {
                Console.Beep();
                return false;
            }
            return true;

        }
        public static bool IsCorreo(string correo)
        {
            bool isArroba = false;
            bool isPunto = false;
            bool isPuntoNext = false;
            foreach (char a in correo.ToCharArray())
            {
                if (isArroba && isPunto) isPuntoNext = true;
                if (isArroba && a == '.')
                {
                    if (!isPunto) isPunto = true;
                    else
                    {
                        isPuntoNext = false;
                        break;
                    }

                }

                if (a == '@')
                {
                    if (!isArroba) isArroba = true;
                    else
                    {
                        isPuntoNext = false;
                        break;
                    }

                }



            }
            if (isPuntoNext)
                return true;
            return false;
        }

    }
}
