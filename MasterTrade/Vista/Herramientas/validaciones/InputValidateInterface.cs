using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MasterTrade.Vista.Herramientas.validaciones
{
    public interface InputValidateInterface
    {
 

     
        public SolidColorBrush colorNegate { get; set; }
        public SolidColorBrush colorValid { get; set; }

        public bool validRequerido();
        public bool validMax();
        public bool validMin();
       
        public bool isValido();

    }
}
