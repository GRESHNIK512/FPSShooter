using Entitas;

namespace InputSys
{
    internal class InputSystems : Systems
    {
        internal InputSystems(Contexts contexts)
        {
            Add(new JoysticControlExecuteSystem(contexts));
            Add(new SwipeExecuteSystem(contexts));
        }
    }
}