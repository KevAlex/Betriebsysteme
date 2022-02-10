namespace LogicaFirstCome
{
    public static class EstadoInicial
    {
        public static List<Proceso> InicialProceso { get; set; } = new List<Proceso>();

        public static Queue<Proceso> ProcesosListos { get; set; } = new Queue<Proceso>();

        public static List<Proceso> FinalProceso { get; set; } = new List<Proceso>();


        public static bool ProcesoBloqueado { get; set; } = false;

        public static bool Semaforo { set; get; } = false;

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
                interno.Enqueue(item);
            }

            return interno;
        }


        public static void EnEspera()
        {
            foreach (Proceso item in ProcesosListos)
            {
                item.TiempoEspera++;
            }
        }
    }
}
