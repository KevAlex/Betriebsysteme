namespace LogicaFirstCome
{
    public class Proceso
    {
        public string Name { get; set; }
        public int TiempoLlegada { get; set; } = 0;
        public int Rafaga { get; set; } = 0;
        public int TiempoComienzo { get; set; } = 0;
        public int TiempoFinal { get; set; } = 0;

        public int TiempoEspera { get; set; } = 0;

        public int TiempoRetorno { get; set; } = 0;
        public bool Bloqueado { get; set; } = false;

        public int RafagaTemporal { get; set; } = 0;


    }

}




//private int myPropertyVar;

//public int MyProperty
//{
//    get { return myPropertyVar; }
//    set { myPropertyVar = value; }
//}


