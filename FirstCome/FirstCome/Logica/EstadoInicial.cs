namespace FirstCome.Logica
{
    public class EstadoInicial
    {
        public static List<Proceso> InicialProceso { get; set; } = new List<Proceso>();

        public static Queue<Proceso> ProcesosListos { get; set; } = new Queue<Proceso>();
        public static List<Proceso> FinalProceso { get; set; } = new List<Proceso>();

        public static List<Proceso> ListaEjecucion { get; set; } = new List<Proceso>();

        public static bool ProcesoBloqueado { get; set; } = false;

        public static bool Semaforo { set; get; } = false;

        public static int TiempoGlobal { get; set; } = 0;

        public static void AgregarProceso(Proceso nuevoProceso)
        {
            InicialProceso.Add(nuevoProceso);
        }

        // Organizando lista inicial (?)
        public static Queue<Proceso> OrganizarLista(List<Proceso> listaInicial)
        {
            Queue<Proceso> interno = new Queue<Proceso>();
            // Organizando la lista basado en la rafaga
            List<Proceso> sortedProcesos = listaInicial.OrderBy(o => o.TiempoLlegada).ToList();

            foreach (Proceso item in sortedProcesos)
            {
                // Dos rafagas iguales definir logica para ordenar?
                item.RafagaTemporal = item.Rafaga;
                interno.Enqueue(item);
                //Console.WriteLine($"name: {item.Name}, Rafaga: {item.Rafaga}");
            }

            return interno;
        }


        // organizando la cola
        public static Queue<Proceso> OrganizarCola(Queue<Proceso> cola)
        {
            Queue<Proceso> interno = new Queue<Proceso>();
            List<Proceso> sortedProcesos = new List<Proceso>();
            // Organizando la lista basado en la rafaga
            sortedProcesos = cola.OrderBy(o => o.RafagaTemporal).ToList();

            //foreach (Proceso item in cola)
            //{
            //    //if (item.TiempoLlegada <= EstadoInicial.TiempoGlobal)
            //    //{
            //    //&& (cola.Any(t => t.Name == item.Name)) == false
            //    sortedProcesos.Add(item);
            //    //interno.Enqueue(item);

            //    //}

            //    // Dos rafagas iguales definir logica para ordenar?
            //    //item.RafagaTemporal = item.Rafaga;
            //    Console.WriteLine($"name: {item.Name}, Rafaga: {item.Rafaga}");
            //}
            //sortedProcesos = sortedProcesos.OrderBy(o => o.RafagaTemporal).ToList();

            foreach (var item in sortedProcesos)
            {
                interno.Enqueue(item);
            }

            //interno = (Queue<Proceso>)interno.OrderBy(o => o.RafagaTemporal);

            //List<Proceso> sortedProcesos = interno.OrderBy(o => o.RafagaTemporal).ToList();

            return interno;
        }
        public static Task AumentarTiempoEspera()
        {
            //await Task.Run(() =>
            //{

            //string[] bloqueado = 
            if (ProcesosListos.Count != 0)
            {
                foreach (Proceso item in ProcesosListos)
                {
                    // Este tiempo se debe aumentar de acuerdo al tiempo general 
                    if (item.FueBloqueado == true)
                    {
                        item.TiempoEspera++;
                        Console.WriteLine($"Aumentado tiempo de espera para {item.Name} el tiempo es: {item.TiempoEspera}");

                    }

                }
            }

            //});

            return Task.CompletedTask;


        }
    }
}
