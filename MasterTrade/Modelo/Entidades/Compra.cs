using MasterTrade.Modelo.Heredable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTrade.Modelo.Entidades
{
    public class Compra : BaseData
    {
        public int Id { get; set; }
      
        public int NFactura { get; set; }
        public int NControl { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorDolar { get; set; }
        public DateTime FechaCompra { get; set; }
        [MaxLength(200)]
        public string? Descripcion { get; set; }
       
        //relation
        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<CompraProducto> CompraProducto { get; private  set; } = new ObservableCollection<CompraProducto>();
    }
    
}
