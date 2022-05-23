using MasterTrade.Modelo.Heredable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MasterTrade.Modelo.Entidades
{
    public class Proveedor : PersonaBaseData
    {
        //  relation
        public virtual ICollection<Compra> Compras { get; private set; } = new ObservableCollection<Compra>();
    }
}
