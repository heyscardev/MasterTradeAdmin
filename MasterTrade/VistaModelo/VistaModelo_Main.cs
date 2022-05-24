using MasterTrade.Clases;

namespace MasterTrade.VistaModelo
{
    class VistaModelo_Main : ObjetoObservable
    {
        //COMANDOS PARA CAMBIAR VISTAS
        public ComandoRelay VistaInicioComando { get; set; }
        public ComandoRelay VistaRegistroComando{ get; set; }
        public ComandoRelay VistaProveedoresComando{ get; set; }
        public ComandoRelay VistaProductosComando { get; set; }
        public ComandoRelay VistaComprarComando { get; set; }
        public ComandoRelay VistaVenderComando { get; set; }
        //COMANDOS PARA CAMBIAR VISTAS

        //DECLARACIÓN DE LAS VISTAS
        public VistaModelo_Inicio VMInicio { get; set; }
        public VistaModelo_Registro VMRegistro { get; set; }
        public VistaModelo_Proveedores VMProveedores { get; set; }
        public VistaModelo_Productos VMProductos { get; set; }
        public VistaModelo_Comprar VMComprar { get; set; }
        public VistaModelo_Vender VMVender { get; set; }
        //DECLARACIÓN DE LAS VISTAS


        private object vista_actual;

        public object VistaActual
        {
            get { return vista_actual; }
            set {
                vista_actual = value;
                OnPropertyChanged();
            }
        }

        public VistaModelo_Main()
        {
            VMInicio = new VistaModelo_Inicio();
            VMRegistro = new VistaModelo_Registro();
            VMProveedores = new VistaModelo_Proveedores();
            VMProductos = new VistaModelo_Productos();
            VMComprar = new VistaModelo_Comprar();
            VMVender = new VistaModelo_Vender();

            VistaActual = VMInicio;

            VistaInicioComando = new ComandoRelay(o =>
            {
                VistaActual = VMInicio;
            });

            VistaRegistroComando = new ComandoRelay(o => 
            {
                VistaActual = VMRegistro;
            });

            VistaProveedoresComando = new ComandoRelay(o =>
            {
                VistaActual = VMProveedores;
            });

            VistaProductosComando = new ComandoRelay(o =>
            {
                VistaActual = VMProductos;
            });

            VistaComprarComando = new ComandoRelay(o =>
            {
                VistaActual = VMComprar;
            });

            VistaVenderComando = new ComandoRelay(o =>
            {
                VistaActual = VMVender;
            });
        }
    }
}
