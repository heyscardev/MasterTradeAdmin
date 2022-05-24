using MasterTrade.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterTrade.Clases
{
    class ComandoBotones : ICommand
    {
        VistaModelo_Registro vistamodelo;

        public ComandoBotones(VistaModelo_Registro vista_parameter)
        {
            vistamodelo = vista_parameter;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            vistamodelo.OnExcecute();
        }
    }
}
