using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MasterTrade.Vista.Herramientas.validaciones
{
    public class InputTexboxValidate : Validaciones, InputValidateInterface
    {
        private string validaciones { get; set; }
        public TextBox input { get; set; }
        // validaciones
        private int minLetter = -1;
        private int maxLetter = -1;
        private bool reque = false;
        private bool telefono = false;
        private bool correo = false;
        private bool sLetras = false;
        private bool sNumeros = false;
        public SolidColorBrush colorNegate { get; set; } = Brushes.Red;
        public SolidColorBrush colorValid { get; set; } = Brushes.Green;
        //constructores
        public InputTexboxValidate(TextBox t, string validaciones, SolidColorBrush colorNegate, SolidColorBrush colorValid)
        {
            this.validaciones = validaciones;
            this.input = t;
            this.colorNegate = colorNegate;
            this.colorValid = colorValid;
                 reque = false;
                 telefono = false;
                 correo = false;
                 sLetras = false;
                 sNumeros = false;
    }
        public InputTexboxValidate(TextBox t, string validaciones)
        {
            this.validaciones = validaciones;
            this.input = t;
            reque = false;
            telefono = false;
            correo = false;
            sLetras = false;
            sNumeros = false;
        }
        private bool establecerReglas()
        {
            var descomposicion = this.validaciones.Replace(" ",String.Empty).Split("|");
            foreach (string attr in descomposicion)
            {
                
                var regla = attr.ToLower().Split(':');
                if (regla.Length == 1)
                {
                    switch (regla[0])
                    {
                        case "requerido":
                         
                    if (!reque)
                            requerido();
                            break;
                        case "correo":
                            if (!correo && !sLetras && !sNumeros && !telefono) email();
                            break;
                        case "telefono":
                            if (!correo && !sLetras && !sNumeros && !telefono) phone();
                            break;
                        case "solonumeros":
                            if (!correo && !sLetras && !sNumeros && !telefono) soloNumeros();
                            break;
                        case "sololetras":
                            if (!correo && !sLetras && !sNumeros && !telefono) email();
                            break;
                    }
                }
                else if (regla.Length == 2)
                {
                    switch (regla[0].ToLower())
                    {
                        case "requerido":
                            if (!regla[1].Equals("false") && !reque ) requerido(); ;
                            break;
                        case "correo":
                            if (!regla[1].Equals("false") && !correo && !sLetras && !sNumeros && !telefono) email();
                            break;
                        case "telefono":
                            if (!regla[1].Equals("false") && !correo && !sLetras && !sNumeros && !telefono) phone();
                            break;
                        case "solonumeros":
                            if (!regla[1].Equals("false") && !correo && !sLetras && !sNumeros && !telefono) soloNumeros();
                            break;
                        case "sololetras":
                            if (!regla[1].Equals("false") && !correo && !sLetras && !sNumeros && !telefono) email();
                            break;
                        case "max":
                            max(regla[1]);
                            break;
                        case "min":
                            min(regla[1]);
                            break;
                    }
                }
            }
            return true;
        }

        public bool isValido()
        {

          
                            if (reque && !this.validRequerido()) return false;

                            if (correo && !this.validEmail()) return false;
                      
                            if (telefono && !validPhone() ) return false;
                       
                            if (sNumeros && !validSoloNumeros()) return false;
                   
                           
                            if (sLetras && !validSoloLetras()) return false;
                     
                            if (maxLetter != -1 && !validMax()) return false;
                        
                            if (minLetter != -1 && !validMin()) return false;
                   
            return true;
        }
        public InputTexboxValidate max(string maximo)
        {
            if (this.isNumeric(maximo) && int.Parse(maximo)>0)
            {
                input.MaxLength = int.Parse(maximo);
                maxLetter = int.Parse(maximo);
            }
            return this;
        }
        public InputTexboxValidate min(string minimo)
        {
            if (this.isNumeric(minimo) &&  int.Parse(minimo)>= 0) this.minLetter = int.Parse(minimo);
            return this;
        }
        public InputTexboxValidate requerido()
        {
            if(!this.correo && !this.telefono) this.input.KeyUp += this
                   .eventoNoVacioKeyUpTexBox;
            reque = true;
            return this;
        }
        public InputTexboxValidate email()
        {
            this.input.KeyUp += this.eventoValidaCorreoTexBox;
            correo = true;
            return this;
        }
        public InputTexboxValidate soloLetras()
        {
            this.input.KeyDown += this.eventoSoloLetrasKeyDownTexBox;
            sLetras = true;
            return this;
        }
        public InputTexboxValidate soloNumeros()
        {
            this.input.KeyDown += this.eventoSoloNumerosKeyDownTexBox;
            sNumeros = true;
            return this;
        }
        public InputTexboxValidate phone()
        {
            this.input.KeyUp += this.eventoValidaTelefono;
            telefono = true;
            return this;
        }
        public bool validRequerido()
        {
                if (this.isVacio(this.input.Text) && this.reque) return false;
                return true;
        }
        public bool validMax()
        {
            if (this.maxLetter != 1 && this.maxLetter < this.input.Text.Length) return false;
            return true;
        }
        public bool validMin()
        {
            if (this.minLetter != 1 && this.minLetter > this.input.Text.Length) return false;
            return true;
        }
        public bool validEmail()
        {
            if (this.isCorreo(this.input.Text)||  this.isVacio(this.input.Text)) return true;
            return false;
        }
        public bool validSoloLetras()
        {
            if (this.isAlphabet(this.input.Text)) return true;
            return false;
        }
        public bool validSoloNumeros()
        {
            if (this.isNumeric(this.input.Text)) return true;
            return false;
        }
        public bool validPhone()
        {
            if (this.isPhoneInternacional(this.input.Text) || isPhoneNacional(this.input.Text)) return true;
            return false;
        }

        public void eventoSoloLetrasKeyDownTexBox(object sender, KeyEventArgs e)
        {
            if (!this.isKeyAlphabet(e.Key) && !this.isKeyFunctional(e.Key))
            {
                e.Handled = true;
                Console.Beep();
            }
        }
        public void eventoSoloNumerosKeyDownTexBox(object sender, KeyEventArgs e)
        {
            if (!this.isKeyNumeric(e.Key) && !this.isKeyFunctional(e.Key) )
            {
                e.Handled = true;
                Console.Beep();
            }
           
        }
        public void eventoNoVacioKeyUpTexBox(object sender, KeyEventArgs e)
        {


            if (!this.isVacio(this.input.Text)) this.input.Background = this.colorNegate;
            else this.input.Background = this.colorValid;
        }
        public void eventoValidaCorreoTexBox(object sender, KeyEventArgs e)
        {
          
            if (this.isCorreo(this.input.Text))
            {
                if ((reque && validRequerido()) || (!reque && !validRequerido()))
                    this.input.Background = this.colorValid;
                else this.input.Background = this.colorNegate;
            }
            else this.input.Background = this.colorNegate;
        }
        public void eventoValidaTelefono(object sender, KeyEventArgs e)
        {
            if (!isKeyNumericPhone(e.Key)) e.Handled = true;
            if (
                this.isPhoneInternacional(this.input.Text)
                || this.isPhoneNacional(this.input.Text)
                ) {
                this.input.Background = this.colorValid;
                if (!reque && validRequerido())
                    this.input.Background = this.colorNegate;
            }
            
            this.input.Background = this.colorNegate;
        }
    }
}
