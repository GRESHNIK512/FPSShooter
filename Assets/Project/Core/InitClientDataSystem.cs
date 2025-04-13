using Entitas;

namespace Core
{
    internal class InitClientDataSystem : IInitializeSystem
    {
        private Contexts _context;

        public InitClientDataSystem(Contexts context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var clientDataEnt = _context.data.CreateEntity();
            clientDataEnt.isClientData = true;
            clientDataEnt.AddKeyData("ClientData");
            clientDataEnt.isLoadData = true;
        }
    }
}