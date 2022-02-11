namespace LogicaFirstCome
{
    public class EstadoEjecucion
    {

        /* private readonly EstadoInicial _estadoInicial;
         EstadoBloqueo estadoBloqueo;

         public EstadoEjecucion(EstadoInicial estadoInicial)
         {
             _estadoInicial = estadoInicial;
         }
        */

        EstadoBloqueo estadoBloqueo = new EstadoBloqueo();
        public async Task Ejecutar(Proceso procesoN)
        {
            EstadoInicial.ProcesoBloqueado = false;

            if (procesoN.Bloqueado == false)
            {
                procesoN.TiempoComienzo = EstadoInicial.TiempoGlobal; // Debe ser el TiempoGeneral

            }

            EstadoInicial.Semaforo = true;
            Console.WriteLine("Proceso en ejecucion " + procesoN.Name + " Llegada " + procesoN.TiempoLlegada + " Rafaga " + procesoN.Rafaga + " RafTem: " + procesoN.RafagaTemporal
                + " Tiempo General " + EstadoInicial.TiempoGlobal);


            while (procesoN.RafagaTemporal > 0 && EstadoInicial.ProcesoBloqueado == false)
            {
                procesoN.RafagaTemporal -= 1;

                EstadoInicial.TiempoGlobal++;

                //await EstadoInicial.AumentarTiempoEspera();

                //if (procesoN.Name.Equals("c"))
                //{
                //    EstadoInicial.ProcesoBloqueado = true;
                //}
            }
            if (EstadoInicial.ProcesoBloqueado == true)
            {
                await estadoBloqueo.BloquearProceso(procesoN);
                EstadoInicial.Semaforo = false;

            }
            else if (!(procesoN.RafagaTemporal > 0))
            {
                // Este tiempo final corregirlo para que abarque más casos
                procesoN.TiempoFinal = procesoN.Rafaga + procesoN.TiempoComienzo;
                procesoN.TiempoRetorno = procesoN.TiempoFinal - procesoN.TiempoLlegada;
                procesoN.TiempoEspera = (procesoN.TiempoRetorno - procesoN.Rafaga) + procesoN.TiempoEspera;
                EstadoInicial.FinalProceso.Add(procesoN);
                EstadoInicial.Semaforo = false;
                Console.WriteLine("Finalizado " + procesoN.Name);
                // !!!!end task

            }


        }
    }
}
