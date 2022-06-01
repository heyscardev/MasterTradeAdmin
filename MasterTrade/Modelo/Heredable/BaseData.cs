using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTrade.Modelo.Heredable
{
    public class BaseData
    {
        //data info
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool? visible { get; set; }
    }
}
