using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTrade.Modelo.Heredable
{
    public class BaseData
    {
        //data info
        [Column(Order = 20)]
        public DateTime FechaCreacion { get; set; }
        [Column(Order = 21)]
        public DateTime FechaActualizacion { get; set; }
        [Column(Order = 22)]
        public bool? EstadoBorrado { get; set; }
    }
}
