using Entitas;

namespace Core
{
    internal class FixedCoreSystems : Systems
    {
        internal FixedCoreSystems(Contexts contexts)
        {
            Add(new FixedButton.FixedButtonReactionSystem(contexts));
            Add(new FixedGame.FixedGameControlSystem(contexts)); 
        }
    }
}