using FirstCome.Logica;

namespace FirstCome.Store.State
{
    public record ProcesoState
    {
        public List<Proceso>? CurrentProcesos { get; init; }
    }
}
