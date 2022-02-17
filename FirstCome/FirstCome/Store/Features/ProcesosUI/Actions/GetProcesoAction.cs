using FirstCome.Logica;

namespace FirstCome.Store.Features.ProcesosUI.Actions
{
    public class GetProcesoAction
    {
        public GetProcesoAction(Proceso proceso)
        {
            Proceso = proceso;
        }

        public Proceso Proceso { get; }
    }
}
