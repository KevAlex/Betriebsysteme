namespace FirstCome.Logica
{
    public class BloqueControl
    {
        public readonly StateFacade _stateFacade;
        EstadoEjecucion estadoEjecucion;

        Random rnd = new Random();
        char randomChar;
        int randomRafaga;
        int randomLlegada;
        int contadorNuevo = 4;
        public BloqueControl()
        {
            // _stateFacade = stateFacade;
            estadoEjecucion = new EstadoEjecucion();
        }


        /// <summary>
        /// Debe ser controlado por un boton
        /// </summary>
        /// <returns></returns>
        public async Task IniciarOperacion(Proceso procesoN = null)
        {
            //await AumentarTiempoGeneral();

            // Esta funcion se llevaría a cabo solo cuado se oprime el boton
            // Y no sería hecha con un while sino solo con un if

            await estadoEjecucion.Ejecutar(procesoN);

            /*if (EstadoInicial.ProcesosListos.Count != 0)
            {
                Proceso siguiente = EstadoInicial.ProcesosListos.Dequeue();
                estadoEjecucion.Ejecutar(siguiente);
            }
            */

            /*while (EstadoInicial.ProcesosListos.Count != 0)
            {

                foreach (var item in EstadoInicial.ProcesosListos)
                {
                    Console.WriteLine("Proceso aun Cola " + item.Name + " Rafaga " + item.Rafaga);
                }
                // Revisar se debo usar un while o mejor if + foreach
                Proceso siguiente = EstadoInicial.ProcesosListos.Dequeue();

                estadoEjecucion.Ejecutar(siguiente);

            }*/
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
        public Task AgregarProcesoInicial()
        {
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "A", Rafaga = 1, TiempoLlegada = 3 });
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "b", Rafaga = 1, TiempoLlegada = 5 });
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "c", Rafaga = 1, TiempoLlegada = 1 });
            //_estadoInicial.InicialProceso.Add(new Proceso { Name = "d", Rafaga = 1, TiempoLlegada = 0 });

            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'a', Rafaga = 8, TiempoLlegada = 0 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'b', Rafaga = 4, TiempoLlegada = 1 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'c', Rafaga = 9, TiempoLlegada = 2 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'd', Rafaga = 5, TiempoLlegada = 3 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'e', Rafaga = 2, TiempoLlegada = 4 });


            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'a', Rafaga = 5, TiempoLlegada = 0 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'b', Rafaga = 3, TiempoLlegada = 1 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'c', Rafaga = 2, TiempoLlegada = 2 });
            //EstadoInicial.InicialProceso.Add(new Proceso { Name = 'd', Rafaga = 1, TiempoLlegada = 3 });

            for (int i = 0; i < 5; i++)
            {
                randomChar = (char)rnd.Next('a', 'z');
                randomRafaga = rnd.Next(2, 5);
                EstadoInicial.InicialProceso.Add(new Proceso { Name = randomChar, TiempoLlegada = i, Rafaga = randomRafaga });
                Console.WriteLine(randomChar);
            }


            EstadoInicial.ProcesosListos = EstadoInicial.OrganizarLista(EstadoInicial.InicialProceso);

            return Task.CompletedTask;
        }

        public Task AgregarNuevoProceso()
        {
            contadorNuevo++;
            randomChar = (char)rnd.Next('a', 'z');
            randomRafaga = rnd.Next(2, 5);
            EstadoInicial.ProcesosListos.Enqueue(new Proceso { Name = randomChar, TiempoLlegada = contadorNuevo, Rafaga = randomRafaga, RafagaTemporal = randomRafaga });
            return Task.CompletedTask;

        }
    }
}
