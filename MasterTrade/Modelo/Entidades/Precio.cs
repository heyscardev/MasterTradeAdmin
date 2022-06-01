using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTrade.Modelo.Entidades
{
    public class Precio
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeMayorista { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeGeneral { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeCredito { get; set; }
        public int ProductoId { get; set; }
        public virtual Producto Producto { get ;set;}
    }
}
