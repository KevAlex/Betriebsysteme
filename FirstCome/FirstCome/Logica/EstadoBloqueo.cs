namespace FirstCome.Logica
{
    public class EstadoBloqueo
    {
        public Task BloquearProceso(Proceso procesoB)
        {
            //for (int i = 0; i < 2; i++)
            //{
            //    procesoB.TiempoEspera += 2; 

            //}
            //procesoB.TiempoEspera += 1;
            // parece que sobra
            procesoB.Bloqueado = true;
            // para aumentarle el tiempo 
            // parece que sobra
            procesoB.FueBloqueado = true;
            // Lo moví al index para renderizarlo mejor
            //EstadoInicial.ListaEjecucion.Remove(procesoB);
            EstadoInicial.ProcesosListos.Enqueue(procesoB);
            Console.WriteLine("Proceso bloqueado " + procesoB.Name + " Rafaga Temporal " + procesoB.RafagaTemporal + " Espera " + procesoB.TiempoEspera);
            return Task.CompletedTask;
        }
    }
}
