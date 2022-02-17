using FirstCome.Logica;
using FirstCome.Store.Features.ProcesosUI.Actions;
using Fluxor;

namespace FirstCome
{
    public class StateFacade
    {
        private readonly ILogger<StateFacade> _logger;
        private readonly IDispatcher _dispatcher;

        public StateFacade(ILogger<StateFacade> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);


        public void AddProceso(Queue<Proceso> procesos)
        {
            _logger.LogInformation("Añadiendo procesos");

            foreach (Proceso item in procesos)
            {
                _dispatcher.Dispatch(new GetProcesoAction(item));

            }
        }

        public Task nuevoAtributo(Proceso proceso)
        {
            _logger.LogInformation("Moviendo propiedad");

            _dispatcher.Dispatch(new CambiaProcesoAction(proceso));

            return Task.CompletedTask;
        }

    }
}
