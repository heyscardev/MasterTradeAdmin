using MasterTrade.Modelo.Enums;
using MasterTrade.Modelo.Heredable;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MasterTrade.Modelo.Entidades
{
    [Index(nameof(NombreUsuario), IsUnique = true)]
    public class Usuario : PersonaBaseData
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string NombreUsuario { get; set; }
        [MaxLength(100)]
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(200)]
        public string Apellido { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Auditoria> Auditoria { get; private set; } = new ObservableCollection<Auditoria>();

    }
   
}
