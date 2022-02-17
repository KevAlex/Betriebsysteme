namespace LogicaFirstCome
{
    public class EstadoBloqueo
    {
        //private readonly EstadoInicial _estadoInicial;


        public Task BloquearProceso(Proceso procesoB)
        {
            Console.WriteLine("Proceso bloqueado " + procesoB.Name + " " + procesoB.Rafaga);
            for (int i = 0; i < 2; i++)
            {
                procesoB.TiempoEspera += 2; // Usar el t

            }
            procesoB.TiempoEspera += 2;
            EstadoInicial.ProcesosListos.Enqueue(procesoB);
            return Task.CompletedTask;
        }
    }
}
