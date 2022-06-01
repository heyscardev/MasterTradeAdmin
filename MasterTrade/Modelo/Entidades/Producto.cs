using MasterTrade.Modelo.Heredable;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTrade.Modelo.Entidades
{
    public class Producto: BaseData
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [MinLength(10)]
        public string CodProducto { get; set; }
        [MaxLength(50)]
        public string CodBarras { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int? StockMax { get; set; }
        public int? StockMin { get; set; }



        //relations
        public virtual ICollection<Precio> Precios { get; private set; } = new ObservableCollection<Precio>();
        public virtual ICollection<CompraProducto> ComprasProductos { get; private set; } = new ObservableCollection<CompraProducto>();
        public virtual ICollection<VentaProducto> VentasProductos { get; private set; } = new ObservableCollection<VentaProducto>();
    }
}
