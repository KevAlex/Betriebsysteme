namespace LogicaFirstCome
{
    public class EstadoBloqueo
    {
        //private readonly EstadoInicial _estadoInicial;


        public Task BloquearProceso(Proceso procesoB)
        {
            Console.WriteLine("Proceso bloqueado " + procesoB.Name + " " + procesoB.Rafaga);
            //for (int i = 0; i < 2; i++)
            //{
            //    procesoB.TiempoEspera += 2; 

            //}
            procesoB.TiempoEspera += 1;
            procesoB.Bloqueado = true;
            EstadoInicial.ProcesosListos.Enqueue(procesoB);
            return Task.CompletedTask;
        }
    }
}
