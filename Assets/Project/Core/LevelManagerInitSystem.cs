using Entitas;

namespace Core
{
    internal class LevelManagerInitSystem : IInitializeSystem
    {
        private Contexts _context;

        public LevelManagerInitSystem(Contexts context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var levelManagerEnt = _context.game.CreateEntity();
            levelManagerEnt.isLevelManager = true; 
        }
    }
}