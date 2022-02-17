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

        public static Queue<Proceso> OrganizarLista(List<Proceso> listaInicial)
        {
            Queue<Proceso> interno = new Queue<Proceso>();
            List<Proceso> sortedProcesos = InicialProceso.OrderBy(o => o.TiempoLlegada).ToList();

            foreach (Proceso item in sortedProcesos)
            {
                item.RafagaTemporal = item.Rafaga;
                interno.Enqueue(item);
            }

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
