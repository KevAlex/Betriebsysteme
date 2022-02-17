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
            procesoN.TiempoComienzo = 5; // Debe ser el TiempoGeneral
            EstadoInicial.Semaforo = true;
            Console.WriteLine("Proceso en ejecucion " + procesoN.Name + " " + procesoN.TiempoLlegada + " Rafaga " + procesoN.Rafaga);

            while (procesoN.Rafaga > 0 && EstadoInicial.ProcesoBloqueado == false)
            {
                procesoN.Rafaga -= 1;
                if (procesoN.Name.Equals("c"))
                {
                    EstadoInicial.ProcesoBloqueado = true;
                }
            }
            if (EstadoInicial.ProcesoBloqueado == true)
            {
                await estadoBloqueo.BloquearProceso(procesoN);
                EstadoInicial.Semaforo = false;

            }
            else if (!(procesoN.Rafaga > 0))
            {
                // Este tiempo final corregirlo para que abarque más casos
                procesoN.TiempoFinal = procesoN.TiempoComienzo + procesoN.TiempoLlegada;
                procesoN.TiempoRetorno = procesoN.TiempoFinal - procesoN.TiempoLlegada;
                procesoN.TiempoEspera = procesoN.TiempoRetorno - procesoN.Rafaga;
                EstadoInicial.FinalProceso.Add(procesoN);
                EstadoInicial.Semaforo = false;
                Console.WriteLine("Finalizado " + procesoN.Name);
                // !!!!end task

            }


        }
    }
}
