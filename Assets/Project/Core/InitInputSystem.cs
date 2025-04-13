using Entitas;

namespace Core
{
    internal class InitInputSystem : IInitializeSystem
    {
        private Contexts _context;

        public InitInputSystem(Contexts context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.input.CreateEntity().isInput = true;
        }
    }
}