using MasterTrade.Modelo.Heredable;
using System.ComponentModel.DataAnnotations;

namespace MasterTrade.Modelo.Entidades
{
    public class Auditoria: BaseData
    {
        public int Id { get; set; }
        public int UsuarioId   { get; set; }
        [MaxLength(80)]
        public string Modulo { get; set; }
        [MaxLength(200)]
        public string Operacion { get; set; }
        [MaxLength(150)]
        public string Observacion { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
