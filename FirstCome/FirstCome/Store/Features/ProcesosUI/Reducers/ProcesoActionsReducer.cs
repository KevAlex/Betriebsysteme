using FirstCome.Store.Features.ProcesosUI.Actions;
using FirstCome.Store.State;
using Fluxor;

namespace FirstCome.Store.Features.ProcesosUI.Reducers
{
    public class ProcesoActionsReducer
    {
        [ReducerMethod]
        public static ProcesoState ReduceGetProcesoAction(ProcesoState state, GetProcesoAction action)
        {
            try
            {
                bool isInList = state.CurrentProcesos.Any(t => t.Name == action.Proceso.Name);
                if (isInList == false)
                {
                    state.CurrentProcesos.Add(action.Proceso);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;

            }

            ProcesoState updatedStateList = state with
            {
                CurrentProcesos = state.CurrentProcesos
            };

            return updatedStateList;
        }

        [ReducerMethod]
        public static ProcesoState ReduceCambiaProcesoAction(ProcesoState state, CambiaProcesoAction action)
        {
            foreach (var item in state.CurrentProcesos.Where(t => t.Name == action.Proceso.Name))
            {
                //item.Name = "Actuala";
                item.TiempoComienzoAlterno = action.Proceso.TiempoComienzoAlterno;
                //  item.PosicionUI = action.Proceso.PosicionUI;
            }

            ProcesoState valueChangedList = state with
            {
                CurrentProcesos = state.CurrentProcesos
            };

            return valueChangedList;

        }

    }


}
