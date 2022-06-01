using MasterTrade.Modelo.Heredable;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTrade.Modelo.Entidades
{
    public class VentaProducto : BaseData
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        // relations
        public int ValorDollarId { get; set; }
        public virtual ValorDollar ValorDollar { get; set; }
        public int ImpuestoId { get; set; }
        public virtual Impuesto Impuesto { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public int VentaId { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
