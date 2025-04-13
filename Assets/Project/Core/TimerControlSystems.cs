using Entitas;

namespace Core
{
    internal class TimerControlSystems : Systems
    {
        internal TimerControlSystems(Contexts contexts)
        {
            Add(new TimersAddDestroyEntSysten(contexts));
            Add(new CommonEndTimersSystem(contexts));

            Add(new EndRefreshWindowTimerSystem(contexts));
        }
    }
}