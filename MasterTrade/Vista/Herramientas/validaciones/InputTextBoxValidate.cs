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
            traducirReglas(validaciones);
         }
        public InputTexboxValidate(TextBox t, string validaciones)
        {
            this.validaciones = validaciones;
            this.input = t;
            traducirReglas(validaciones);
        }
        private void traducirReglas(string reglas)
        {
            var descomposicion = this.validaciones.Replace(" ", String.Empty).Split("|");
            foreach (string attr in descomposicion)
            {

                var regla = attr.ToLower().Split(':');
                if (regla.Length == 1)
                {
                    switch (regla[0])
                    {
                        case "requerido":
                            reque = true;
                            break;
                        case "correo":
                            correo = true;
                            break;
                        case "telefono":
                            telefono = true;
                            break;
                        case "solonumeros":
                            sNumeros = true;
                            break;
                        case "sololetras":
                            sLetras = true;
                            break;
                    }
                }
                else if (regla.Length == 2)
                {
                    switch (regla[0].ToLower())
                    {
                        case "requerido":
                            if (!regla[1].Equals("true")) reque = true;
                                break;
                        case "correo":
                            if (!regla[1].Equals("false")) correo = true;
                            break;
                        case "telefono":
                            if (!regla[1].Equals("false")) telefono = true;
                            break;
                        case "solonumeros":
                            if (!regla[1].Equals("false")) sNumeros = true;
                            break;
                        case "sololetras":
                            if (!regla[1].Equals("false")) sLetras = true;
                            break;
                        case "max":
                            if (isNumeric(regla[1]) && int.Parse(regla[1])>= 0) maxLetter = int.Parse(regla[1]);
                            break;
                        case "min":
                            if (isNumeric(regla[1]) && int.Parse(regla[1])>= 0) minLetter = int.Parse(regla[1]);
                            break;
                    }
                }
            }
        }
        private void establecerReglas()
        {
            if (correo) this.email();
            else if (telefono)this.phone();
            else if (sLetras) this.soloLetras();
            else if (sNumeros) this.soloNumeros();
            if (!correo && !telefono && reque) requerido();
            if (maxLetter != -1) this.max(maxLetter);
            if (minLetter != -1) this.min(minLetter);
        }

        public bool isValido()
        {
            if (reque && !this.validRequerido())
            {
                MessageBox.Show("el campo: '" + input.Name + " es obligatorio ");
                return false;
            }

            if (correo )
            {
                if (reque && this.isCorreo(this.input.Text)) this.input.BorderBrush = this.colorValid;
                else if (isVacio(this.input.Text) || this.isCorreo(this.input.Text)) this.input.BorderBrush = this.colorValid;
                else
                {
                    MessageBox.Show("el correo: '" + input.Text + "' no es valido intente en formato 'example@example.com'");
                    input.BorderBrush = this.colorNegate;
                    return false;
                }
                
            }
            if (telefono )
            {
                if (reque && (this.isPhoneInternacional(this.input.Text) || isPhoneNacional(this.input.Text))) this.input.BorderBrush = this.colorValid;
                else if (isVacio(this.input.Text) || (this.isPhoneInternacional(this.input.Text) || isPhoneNacional(this.input.Text))) this.input.BorderBrush = this.colorValid;
                else
                {
                    input.BorderBrush = this.colorNegate;
                    MessageBox.Show("el telefono: '" + input.Text + "' no es valido intente en formato '+xx (xxxx) xxx xxxx' o  '(xxxx) xxx xxxx ' ");
                    return false;
                }
            }

            if (maxLetter != -1 && !validMax())
            {
                MessageBox.Show("el elemento: '" + input.Text + "' no cumple con el maximo de caracteres: " + maxLetter);
                return false;
            }

            if (minLetter != -1 && !validMin())
            {
                MessageBox.Show("el elemento: '" + input.Text + "' no cumple con el minimo de caracteres: " + minLetter);
                return false;
            }
           
            return true;
        }
        public InputTexboxValidate max(int maximo)
        {
            if (maximo >= 0)
            {
                input.MaxLength = maximo;
                maxLetter = maximo;
            }
            else this.maxLetter = -1;
            return this;
        }
        public InputTexboxValidate min(int minimo)
        {
            if ( minimo>= 0) this.minLetter = minimo;
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
            this.input.KeyDown += this.eventoEmailKeyDown;
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
            this.input.KeyUp += this.eventoValidaTelefonoKeyUp;
            this.input.KeyDown += this.eventoValidaTelefonoKeyDown;
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
            if (this.isCorreo(this.input.Text)) return true;
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

        private void eventoEmailKeyDown(object sender, KeyEventArgs e)
        {
            
          
        }

        private void eventoSoloLetrasKeyDownTexBox(object sender, KeyEventArgs e)
        {
            if (!this.isKeyAlphabet(e.Key) && !this.isKeyFunctional(e.Key))
            {
                e.Handled = true;
                Console.Beep();
            }
        }
        private void eventoSoloNumerosKeyDownTexBox(object sender, KeyEventArgs e)
        {
            if (!this.isKeyNumeric(e.Key) && !this.isKeyFunctional(e.Key) )
            {
                e.Handled = true;
                Console.Beep();
            }
           
        }
        private void eventoNoVacioKeyUpTexBox(object sender, KeyEventArgs e)
        {


            if (this.isVacio(this.input.Text)) this.input.BorderBrush = this.colorNegate;
            else this.input.BorderBrush = this.colorValid;
        }
        private void eventoValidaCorreoTexBox(object sender, KeyEventArgs e)
        {
           this.input.BorderBrush = this.colorNegate;

            this.input.BorderBrush = this.colorNegate;
            if (reque && this.isCorreo(this.input.Text)) this.input.BorderBrush = this.colorValid;
                else if (isVacio(this.input.Text) || this.isCorreo(this.input.Text)) this.input.BorderBrush = this.colorValid;
          
    

        }
        private void eventoValidaTelefonoKeyDown(object sender, KeyEventArgs e)
        {
            if (!isKeyNumericPhone(e.Key)) e.Handled = true;
        }

        private void eventoValidaTelefonoKeyUp(object sender, KeyEventArgs e)
        {
            this.input.BorderBrush = this.colorNegate;
            if (reque && (this.isPhoneInternacional(this.input.Text)|| isPhoneNacional(this.input.Text))) this.input.BorderBrush = this.colorValid;
            else if (isVacio(this.input.Text) || (this.isPhoneInternacional(this.input.Text) || isPhoneNacional(this.input.Text)) ) this.input.BorderBrush = this.colorValid;
        }
    }
}
