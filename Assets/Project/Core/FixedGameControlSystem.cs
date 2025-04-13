using Entitas;

namespace FixedGame
{
    internal class FixedGameControlSystem : Systems
    {
        internal FixedGameControlSystem(Contexts contexts)
        {
            Add(new PlayerIcreaseVelositySystem(contexts)); 
        }
    }
}