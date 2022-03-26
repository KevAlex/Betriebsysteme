﻿namespace FirstCome.Logica
{
    public class Proceso
    {
        public string Name { get; set; }
        public int TiempoLlegada { get; set; } = 0;
        public int Rafaga { get; set; } = 0;

        public List<int> RafagaH { get; set; } = new List<int>();
        public int TiempoComienzo { get; set; } = 0;
        public List<int> TiempoComienzoH { get; set; } = new List<int>();
        public int TiempoComienzoAlterno { get; set; } = 0;

        public int TiempoFinal { get; set; } = 0;
        public List<int> TiempoFinalH { get; set; } = new List<int>();
        public int TiempoEspera { get; set; } = 0;
        public List<int> EsperaH { get; set; } = new List<int>();
        public int TiempoRetorno { get; set; } = 0;
        public List<int> RetornoH { get; set; } = new List<int>();
        // Determina si el proceso fue bloqueado externamente
        // y sirve para el GUI
        public bool Bloqueado { get; set; } = false;

        // Proceso bloqueado se le aumentara su tiempo
        // de espera Esta variable sobra usar solo Bloqueado
        public bool FueBloqueado { get; set; } = false;

        public int RafagaTemporal { get; set; } = 0;

        public bool Expulsado { get; set; } = false;

    }
}
