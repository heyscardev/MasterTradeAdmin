using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MasterTrade.Clases
{
    class ObjetoObservable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
    }
}
