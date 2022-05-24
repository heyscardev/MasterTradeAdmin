using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MasterTrade.Vista.Herramientas
{
    public class InputForm
    {
        public object input { get; private set; }
        public string reglas {get; private set;}
        public InputForm(object input,string reglas)
        {
            this.input = input;
            this.reglas = reglas;
        }
    }
    public class ValidaFormularios
    {
        private List<InputForm> inputs= new List<InputForm>();
        SolidColorBrush colorNegate { get; set; } = Brushes.Red;
        SolidColorBrush colorValid { get; set; } = Brushes.Green;
      
        public ValidaFormularios(SolidColorBrush colorNegate, SolidColorBrush colorValid)
        {
            inputs = new List<InputForm>();
            this.colorNegate = colorNegate;
            this.colorValid = colorValid;
          }
        public ValidaFormularios()
        {
            inputs = new List<InputForm>();
          
        }
        public InputForm addInput(object input, string keys)
        {
            if(input != null && (input is TextBox || input is DatePicker || input is ComboBox) )
            {
                InputForm nuevo = new InputForm(input, keys);
                inputs.Add(nuevo);
                establishinReglas(input as TextBox,keys);
                return nuevo;
            }
            
            return null;
        }
        public object remove(object input, string keys)
        {
            foreach(var i in inputs)
            {
                if(input == i)
                {
                    inputs.Remove(i);
                    return i;
                }
            }
            return null;
        }

        private void establishinReglas(TextBox sender, string validaciones)
        {
            var descomposicion = validaciones.Split("|");
            foreach (string attr in descomposicion)
            {
                var regla = attr.ToLower().Split(':');
                if (regla.Length == 1)
                {
                    switch (regla[0])
                    {
                        case "requerido":
                            sender.KeyUp += this.eventoNoVacioKeyUpTexBox;
                            break;
                        case "correo":
                            sender.KeyUp += this.eventovalidaCorreoTexBox;
                            break;
                        case "telefono":
                            //futuras validaciones
                            sender.KeyDown += this.eventoSoloNumerosKeyDownTexBox;
                            break;
                        case "solonumeros":
                            sender.KeyDown += this.eventoSoloNumerosKeyDownTexBox;
                            break;
                        case "sololetras":
                            sender.KeyDown += this.eventoSoloLetrasKeyDownTexBox;
                            break;
                    }
                }
                else if (regla.Length == 2)
                {
                    switch (regla[0].ToLower())
                    {
                        case "requerido":
                            if (!regla[1].Equals("false") ) sender.KeyUp += this.eventoNoVacioKeyUpTexBox;
                            break;
                        case "correo":
                            if (!regla[1].Equals("false") ) sender.KeyUp += this.eventovalidaCorreoTexBox;
                            break;
                        case "telefono":
                            //futuras validaciones
                            if (!regla[1].Equals("false") ) sender.KeyDown += this.eventoSoloNumerosKeyDownTexBox;
                            break;
                        case "solonumeros":
                            if (!regla[1].Equals("false") ) sender.KeyDown += this.eventoSoloNumerosKeyDownTexBox;
                            break;
                        case "sololetras":
                            sender.KeyDown += this.eventoSoloLetrasKeyDownTexBox;
                            break;
                        case "maxlength":
                            if (isNumeric(regla[1]))
                            {
                                sender.MaxLength = int.Parse(regla[1]);
                            }
                            break;
                        case "minlength":
                            if (isNumeric(regla[1]))
                            {
                               //no se puede aplicar
                            }
                            break;
                    }
                }
            }
            
        }
        //validar reglas de input
        private bool valido(TextBox sender,string validaciones)
        {
            var descomposicion = validaciones.Split("|");
            foreach(string attr in descomposicion)
            {
                var regla = attr.ToLower().Split(':');
                if (regla.Length == 1)
                {
                    switch (regla[0])
                    {
                        case "requerido":
                            if (isVacio(sender)) return false;
                            break;
                        case "correo":
                            if (!isCorreoNoRequired(sender)) return false;
                            break;
                        case "telefono":
                            //futuras validaciones
                            break;
                        case "solonumeros":
                            if (!isNumeric(sender)) return false;
                            break;
                        case "sololetras":
                            if (!isAlphabet(sender)) return false;
                            break;
                    }
                }
                else if(regla.Length == 2)
                {
                    switch (regla[0].ToLower())
                    {
                        case "requerido":
                            if(!regla[1].Equals("false") && isVacio(sender)) return false;
                            break;
                        case "correo":
                            if (!regla[1].Equals("false") && !isCorreoNoRequired(sender)) return false;
                            break;
                        case "telefono":
                            //futuras validaciones
                            break;
                        case "solonumeros":
                            if (!regla[1].Equals("false") && !isNumeric(sender)) return false;
                            break;
                        case "sololetras":
                            if (!regla[1].Equals("false") &&  !isAlphabet(sender)) return false;
                            break;
                        case "maxlength":
                            if (isNumeric(regla[1])){
                                if (sender.Text.Length > int.Parse(regla[1])) return false;
                            }
                            break;
                        case "minlength":
                            if (isNumeric(regla[1]))
                            {
                                if (sender.Text.Length < int.Parse(regla[1])) return false;
                            }
                            break;
                            }
                }
            }
            return true;
        }
        private bool valido(DatePicker sender, string validaciones)
        {
            var descomposicion = validaciones.Split("|");
            foreach (string attr in descomposicion)
            {
                var regla = attr.ToLower().Split(':');
                if (regla.Length == 1)
                {
                    switch (regla[0])
                    {
                        case "requerido":
                            if (isVacio(sender)) return false;
                            break;
                       
                    }
                }
                else if (regla.Length == 2)
                {
                    switch (regla[0].ToLower())
                    {
                        case "requerido":
                            if (!regla[1].Equals("false") && isVacio(sender)) return false;
                            break;
                        /* maximo de fecha por ahora
                         * case "maxdate":
                            if (isNumeric(regla[1]))
                            {
                                if (sender.Text.Length > int.Parse(regla[1])) return false;
                            }
                            break;
                        case "mindate":
                            if (isNumeric(regla[1]))
                            {
                                if (sender.Text.Length < int.Parse(regla[1])) return false;
                            }
                            break;
                        */
                    }
                }
            }
            return true;
        }
      

        //validaciones eventos
        //vacio
        public static bool isVacio(TextBox input)
        {
             if (input.Text.Length == 0) return true;
            return false;
        }
        public static bool isVacio(ComboBox input)
        {
            if (input.SelectedIndex == -1) return true;
            return false;
        }
        public static bool isVacio(DatePicker input)
        {
            if (input.Text.Length == 0) return true;
            return false;
        }
        // si es numero
        public static bool isNumeric(TextBox input)
        {
            if (Regex.IsMatch(input.Text, @"^[0-9]+$")) return true;
            return false;
        }
        public static bool isNumeric(string input)
        {
            if (Regex.IsMatch(input, @"^[0-9]+$")) return true;
            return false;
        }
        public static bool isAlphabet(TextBox input)
        {
            if (Regex.IsMatch(input.Text, @"^[a-zA-Z]+$")) return true;
            return false;
        }
        public static bool isSelected(ComboBox input)
        {
            return isVacio(input);
        }
        //valida si es un correo valida y si esta vacio devuelve true
        public static bool isCorreoNoRequired(TextBox input)
        {
            if (isVacio(input)) return true;
            bool isArroba = false; // primero comprueba arroba
            bool isPunto = false;//comprueba un punto 
            bool isPuntoNext = false;//comprueba
            //itera todo el strinen busca de este patron nombre@domino.terminacion esto es invalido nombre@@domino..terminacio
            foreach (char a in input.Text.ToCharArray())
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
            if (isPuntoNext)
                return true;
            return false;
        }
        public static bool isCorreoRequired(TextBox input)
        {
            bool isArroba = false; // primero comprueba arroba
            bool isPunto = false;//comprueba un punto 
            bool isPuntoNext = false;//comprueba
            foreach (char a in input.Text.ToCharArray())
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
            if (isPuntoNext)
                return true;
            return false;
        }
        public static bool isKeyNumeric(Key key)
        {
           
             if (
                !(key >= Key.D0 && key <= Key.D9
                || key >= Key.NumPad0 && key <= Key.NumPad9)
                && key != Key.Tab
                && key != Key.Enter
                && key != Key.Back
                )
                return false;
            return true;
            
        }
        public static bool isKeyAlphabet(Key key)
        {
            if (
                !( key >= Key.A && key <= Key.Z)
                && key != Key.Tab
                && key != Key.Enter
                && key != Key.Back
                )
                return false;
            return true;
        }
        
        public  void eventoSoloLetrasKeyDownTexBox(object sender, KeyEventArgs e) {
            TextBox t = sender as TextBox;
            if (isKeyAlphabet(e.Key))
            {
                t.Background = this.colorValid;
                e.Handled = false;
            }
            else
            {
                t.Background = this.colorNegate;
                e.Handled = true;
                Console.Beep();
            }
        }
        public void eventoSoloNumerosKeyDownTexBox(object sender, KeyEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (isKeyNumeric(e.Key))
            { 
            t.Background = this.colorValid;
            e.Handled = false;
            }
            else
            {
                t.Background = this.colorNegate;
                e.Handled = true;
                Console.Beep();
            }
        }

       

        public void eventoNoVacioKeyUpTexBox(object sender, KeyEventArgs e) {
            var t = sender as TextBox;
             
            if (t.Text.Length == 0) t.Background = this.colorNegate;
            else t.Background = this.colorValid;
        }

        public void eventovalidaCorreoTexBox(object sender, KeyEventArgs e)
        {
            TextBox t = sender as TextBox;
            MessageBox.Show(t.Text);
            t.Background = Brushes.Green;
            if (isCorreoNoRequired(t)) t.Background = this.colorValid;
            else t.Background = this.colorNegate;



        }
    }
}

