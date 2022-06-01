using MasterTrade.Modelo.Heredable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTrade.Modelo.Entidades
{
    public class ValorDollar : BaseData
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Valor { get; set; }
        public bool Actual { get; set; }
        public virtual ICollection<CompraProducto> CompraProductos { get; private set; } = new ObservableCollection<CompraProducto>();
        public virtual ICollection<VentaProducto> VentaProductos { get; private set; } = new ObservableCollection<VentaProducto>();
    }
}
