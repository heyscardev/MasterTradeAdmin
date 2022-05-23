using System;
using System.Windows.Input;

namespace MasterTrade.Clases
{
    class ComandoRelay : ICommand
    {
        private Action<object> excecute;
        private Func<object, bool> can_execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ComandoRelay(Action<object> excecute, Func<object, bool> can_execute = null)
        {
            this.excecute = excecute;
            this.can_execute = can_execute;
        }

        public bool CanExecute(object parametro)
        {
            return can_execute == null || can_execute(parametro);
        }

        public void Execute(object parametro)
        {
            excecute(parametro);
        }
    }
}
