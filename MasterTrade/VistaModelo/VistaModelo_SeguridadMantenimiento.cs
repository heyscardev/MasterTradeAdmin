using MasterTrade.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterTrade.VistaModelo
{
    class VistaModelo_SeguridadMantenimiento : ObjetoObservable
    {
        //COMANDOS PARA CAMBIAR VISTAS
        public ComandoRelay VistaRespaldoComando { get; set; }
        public ComandoRelay VistaAuditoriaComando { get; set; }
        public ComandoRelay VistaReportesComando { get; set; }
        public ComandoRelay VistaUsuariosComando { get; set; }
        public ComandoRelay VistaConfiguracionComando { get; set; }
        //COMANDOS PARA CAMBIAR VISTAS

        //DECLARACIÓN DE LAS VISTAS
        public VistaModelo_Respaldo VMRespaldo { get; set; }
        public VistaModelo_Auditoria VMAuditoria { get; set; }
        public VistaModelo_Reportes VMReportes { get; set; }
        public VistaModelo_Usuario VMUsuarios { get; set; }
        public VistaModelo_Configuracion VMConfiguración { get; set; }
        //DECLARACIÓN DE LAS VISTAS

        private object vista_seguridad;

        public object VistaSeguridad
        {
            get { return vista_seguridad; }
            set
            {
                vista_seguridad = value;
                OnPropertyChanged();
            }
        }

        public VistaModelo_SeguridadMantenimiento()
        {
            VMRespaldo = new VistaModelo_Respaldo();
            VMAuditoria = new VistaModelo_Auditoria();
            VMReportes = new VistaModelo_Reportes();
            VMUsuarios = new VistaModelo_Usuario();
            VMConfiguración = new VistaModelo_Configuracion();

            VistaSeguridad = VMRespaldo;

            VistaRespaldoComando = new ComandoRelay(o =>
            {
                VistaSeguridad = VMRespaldo;
            });

            VistaAuditoriaComando = new ComandoRelay(o =>
            {
                VistaSeguridad = VMAuditoria;
            });

            VistaReportesComando = new ComandoRelay(o =>
            {
                VistaSeguridad = VMReportes;
            });

            VistaUsuariosComando = new ComandoRelay(o =>
            {
                VistaSeguridad = VMUsuarios;
            });

            VistaConfiguracionComando = new ComandoRelay(o =>
            {
                VistaSeguridad = VMConfiguración;
            });
        }
    }
}
