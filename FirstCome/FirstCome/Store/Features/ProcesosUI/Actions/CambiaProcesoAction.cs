using FirstCome.Logica;

namespace FirstCome.Store.Features.ProcesosUI.Actions
{
    public class CambiaProcesoAction
    {
        public CambiaProcesoAction(Proceso proceso)
        {
            Proceso = proceso;
        }

        public Proceso Proceso { get; }
    }
}
