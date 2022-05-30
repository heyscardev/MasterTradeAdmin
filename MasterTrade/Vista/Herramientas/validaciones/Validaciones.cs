using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MasterTrade.Vista.Herramientas.validaciones
{
    public class Validaciones
    {
        public  bool isVacio(string text)
        {
            if (text.Length == 0) return true;
            return false;
        }
        public  bool isNumeric(string text)
        {
            if (Regex.IsMatch(text, @"^[0-9]+$")) return true;
            return false;
        }
        public  bool isAlphabet(string text)
        {
            if (Regex.IsMatch(text, @"^[a-zA-Z]+$")) return true;
            return false;
        }
        public  bool isSelected(ComboBox input)
        {
            if (input.SelectedIndex == -1) return true;
            return false;
        }
        public  bool isCorreo(string text)
        {
          
            bool isArroba = false; // primero comprueba arroba
            bool isPunto = false;//comprueba un punto 
            bool isPuntoNext = false;//comprueba
            //itera todo el string busca de este patron nombre@domino.terminacion esto es invalido nombre@@domino..terminacio
            foreach (char a in text.ToCharArray())
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
                //if la letra iterada es arroba 
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

            if (isPuntoNext)return true;
          
            return false;
        }
        public  bool isKeyNumeric(Key key)
        {

            if (
               (key >= Key.D0 && key <= Key.D9)
               || (key >= Key.NumPad0 && key <= Key.NumPad9)
              
               )
                return true;
            return false;

        }
        public bool isKeyCorreo(Key key)
        {
            if (key == Key.Space) return false;
            return true;
        }
        public bool isKeyNumericPhone(Key key)
        {
            
            if (
               ((key >= Key.D0 && key <= Key.D9)
               || (key >= Key.NumPad0 && key <= Key.NumPad9))
               || key == Key.OemPlus
               || key == Key.Add
               || key == Key.OemCloseBrackets 
               || key == Key.OemOpenBrackets
               )
                return true;
            return false;

        }
        public  bool isKeyAlphabet(Key key)
        {
            if (
                   key >= Key.A 
                && key <= Key.Z
                )
                return true;
            return false;
        }
        public  bool isKeyFunctional(Key key) {
            if (
                       key == Key.Tab
                    && key == Key.Enter
                    && key == Key.Back
                    ) return true;
            return false;
            
       
        }
       
         public bool isPhoneInternacional(string text)
         {
            
             var letras = text.Replace(" ", string.Empty).ToCharArray();
             int sCountry = 1;
            if (letras.Length < 12) return false;
             if (letras[0] != '+'  || !isNumeric(letras[1].ToString()) ) return false;
            //rrecorre hasta que encuentra (
            for (int i = 2; i < letras.Length; i++)
             {
                 if (isNumeric(letras[i].ToString())) continue;
                 if (letras[i] != '(') return false;
                 sCountry= i+1;
                break;
             }
             //si el caracter siguiente no existe o si es diferente de un numero retorna false
            if (sCountry >= letras.Length || !isNumeric(letras[sCountry].ToString())) return false;
            sCountry++;
            while( sCountry < letras.Length)
            {
                if (isNumeric(letras[sCountry].ToString())) { sCountry++; continue; }
                if (letras[sCountry] != ')') return false;
                sCountry += 1; ;
                break;
            }
         
            if (sCountry + 6 >= letras.Length)return false;
            for (int i = 1; sCountry < letras.Length; i++)
            {
                if (i > 7) return false;
                if (isNumeric(letras[sCountry].ToString())) { sCountry++ ; continue; }
                return false;
            }
            return true;
        }
        public bool isPhoneNacional(string text)
        {

            var letras = text.Replace(" ", string.Empty).ToCharArray();
            int sCountry = 1;
            if (letras.Length < 10) return false;
            if (letras[0] != '(' || !isNumeric(letras[1].ToString())) return false;

            sCountry++;
            while (sCountry < letras.Length)
            {
                if (isNumeric(letras[sCountry].ToString())) { sCountry++; continue; }
                if (letras[sCountry] != ')') return false;
                sCountry += 1; ;
                break;
            }

            if (sCountry + 6 >= letras.Length) return false;
            for (int i = 1; sCountry < letras.Length; i++)
            {
                if (i > 7) return false;
                if (isNumeric(letras[sCountry].ToString())) { sCountry++; continue; }
                return false;
            }
            return true;
        }
    }
}
