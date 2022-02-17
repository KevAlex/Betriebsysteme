using FirstCome.Logica;
using FirstCome.Store.State;
using Fluxor;

namespace FirstCome.Store.Features.ProcesosUI
{
    public class ProcesoFeature : Feature<ProcesoState>
    {
        public override string GetName() => "Proceso";
        public List<Proceso> initialProceso = new List<Proceso>();
        protected override ProcesoState GetInitialState()
        {
            return new ProcesoState { CurrentProcesos = initialProceso };
        }
    }
}
