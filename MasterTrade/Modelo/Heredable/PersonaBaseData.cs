using MasterTrade.Modelo.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterTrade.Modelo.Heredable
{
    [Index("NumeroIdentificacion", IsUnique = true)]
    public class PersonaBaseData : BaseData
    {
        [Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public TipoIdentificacion TipoIdentificacion { get; set; }
        [MaxLength(20)]
        [Column(Order = 2)]
        public string NumeroIdentificacion { get; set; }
        [Column(Order = 3)]
        [MaxLength(80)]
        public string RazonSocial { get; set; }
        [MaxLength(200)]
        public string? Correo { get; set; }
        [MaxLength(20)]
        [Column(Order = 5)]
        public string? Telefono { get; set; }
        [MaxLength(250)]
        [Column(Order = 6)]
        public string? Direccion { get; set; }


    }
}
