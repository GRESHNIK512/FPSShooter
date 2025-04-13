using Entitas;

namespace Core
{
    internal class WindowControlSystems : Systems
    {
        internal WindowControlSystems(Contexts contexts)
        {
            Add(new RefreshStatusWindowSystem(contexts)); 
        }
    }
}