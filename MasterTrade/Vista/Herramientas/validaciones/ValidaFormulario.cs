using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MasterTrade.Vista.Herramientas.validaciones
{
    public class ValidaFormulario
    {
        private List<InputValidateInterface> inputs = new List<InputValidateInterface>();
        SolidColorBrush colorNegate { get; set; } = Brushes.Red;
        SolidColorBrush colorValid { get; set; } = Brushes.Green;

        public ValidaFormulario(SolidColorBrush colorNegate, SolidColorBrush colorValid)
        {
            inputs = new List<InputValidateInterface>();
            this.colorNegate = colorNegate;
            this.colorValid = colorValid;
        }
        public ValidaFormulario()
        {
            inputs = new List<InputValidateInterface>();

        }
        public bool formularioisValido()
        {
            foreach(InputValidateInterface inp in inputs)
            {
                if (!inp.isValido()) return false;
            }
            return true;
        }
        public InputTexboxValidate addInput(TextBox input, string keys)
        {
            if (input == null) return null;
            var  nuevo = new InputTexboxValidate(input, keys,this.colorNegate,colorValid);
            inputs.Add(nuevo);
          
            return nuevo;
        }
        public object remove(object input, string keys)
        {
            foreach (var i in inputs)
            {
                if (input == i)
                {
                    inputs.Remove(i);
                    return i;
                }
            }
            return null;
        }

    }
}
