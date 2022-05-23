using MasterTrade.Modelo.Heredable;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MasterTrade.Modelo.Entidades
{
    public class Cliente : PersonaBaseData
    {
        public virtual ICollection<Venta> Ventas { get; private set; } = new ObservableCollection<Venta>();
    }
}
