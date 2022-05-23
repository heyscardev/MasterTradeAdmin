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
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeGanancia { get; set; }
        [Column(TypeName ="decimal(12,2)")]
        public decimal ValorDolar { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Precio1 { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Precio2 { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Precio3 { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Impuesto { get; set; }
        [MaxLength(200)]
        public string? Descripcion { get; set; }
        [MaxLength(250)]
        public string? Imagen { get; set; }
       public bool Visible{ get; set; }
        public int? StockMax { get; set; }
        public int? StockMin { get; set; }

        //relations
        public virtual ICollection<CompraProducto> ComprasProductos { get; private set; } = new ObservableCollection<CompraProducto>();
        public virtual ICollection<VentaProducto> VentasProductos { get; private set; } = new ObservableCollection<VentaProducto>();
    }
}
