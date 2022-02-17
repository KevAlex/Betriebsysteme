namespace LogicaFirstCome
{
    // CLase encargada de controlar e inicializar todo
    public class BloqueControl
    {
        /*private readonly EstadoInicial _estadoInicial;
        EstadoEjecucion estadoEjecucion;
        public BloqueControl(EstadoInicial estadoInicial)
        {
            _estadoInicial = estadoInicial;
            estadoEjecucion = new EstadoEjecucion(_estadoInicial);
        }
        */
        EstadoEjecucion estadoEjecucion = new EstadoEjecucion();
        Timer timer = new Timer;
        public async Task IniciarOperacion()
        {
            await AumentarTiempoGeneral();
            while (EstadoInicial.ProcesosListos.Count != 0)
            {
                Console.WriteLine("Entre ");

                foreach (var item in EstadoInicial.ProcesosListos)
                {
                    Console.WriteLine("Proceso en Cola " + item.Name + " Rafaga " + item.Rafaga);
                }
                // Revisar se debo usar un while o mejor if + foreach
                Proceso siguiente = EstadoInicial.ProcesosListos.Dequeue();

                estadoEjecucion.Ejecutar(siguiente);

            }
        }

        // aumentar tiempo de espera
        // Hilos


        // Definir tiempo general

        public async Task AumentarTiempoGeneral()
        {
            //Definirlo
        }

        public async Task AumentarTiempoEspera()
        {
            while (EstadoInicial.ProcesosListos.Count != 0)
            {
                foreach (var item in EstadoInicial.ProcesosListos)
                {
                    // Este tiempo se debe aumentar de acuerdo al tiempo general 
                    item.TiempoEspera++;

                }
            }
        }
        public void AgregarProceso()
        {
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "A", Rafaga = 1, TiempoLlegada = 3 });
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "b", Rafaga = 1, TiempoLlegada = 5 });
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "c", Rafaga = 1, TiempoLlegada = 1 });
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "d", Rafaga = 1, TiempoLlegada = 0 });

            EstadoInicial.InicialProceso.Add(new Proceso { Name = "A", Rafaga = 2, TiempoLlegada = 3 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "b", Rafaga = 1, TiempoLlegada = 5 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "c", Rafaga = 3, TiempoLlegada = 1 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "d", Rafaga = 2, TiempoLlegada = 0 });
            EstadoInicial.ProcesosListos = EstadoInicial.OrganizarLista(EstadoInicial.InicialProceso);

        }
    }
}
