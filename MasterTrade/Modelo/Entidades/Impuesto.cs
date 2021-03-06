


using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MasterTrade.Modelo.Entidades
{
    public class Impuesto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; } 
        public string Descripcion { get; set; }
        public virtual ICollection<CompraProducto> CompraProductos { get; private set; } = new ObservableCollection<CompraProducto>();
        public virtual ICollection<VentaProducto> VentaProductos { get; private set; } = new ObservableCollection<VentaProducto>();
    }
}
