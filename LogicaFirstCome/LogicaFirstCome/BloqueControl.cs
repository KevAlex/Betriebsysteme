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

        public async Task IniciarOperacion()
        {
            //await AumentarTiempoGeneral();
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
            if (EstadoInicial.ProcesosListos.Count == 0)
            {
                foreach (Proceso proceso in EstadoInicial.FinalProceso)
                {
                    Console.WriteLine($"Proceso {proceso.Name}, Llegada {proceso.TiempoLlegada}, Rafaga {proceso.Rafaga}" +
                        $" Comienzo {proceso.TiempoComienzo}, Final: {proceso.TiempoFinal}, Retorno: {proceso.TiempoRetorno}" +
                        $" Espera: {proceso.TiempoEspera}");
                }
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

            EstadoInicial.InicialProceso.Add(new Proceso { Name = "A", Rafaga = 8, TiempoLlegada = 0 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "b", Rafaga = 4, TiempoLlegada = 1 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "c", Rafaga = 9, TiempoLlegada = 2 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "d", Rafaga = 5, TiempoLlegada = 3 });
            EstadoInicial.InicialProceso.Add(new Proceso { Name = "e", Rafaga = 2, TiempoLlegada = 4 });

            EstadoInicial.ProcesosListos = EstadoInicial.OrganizarLista(EstadoInicial.InicialProceso);

        }
    }
}
