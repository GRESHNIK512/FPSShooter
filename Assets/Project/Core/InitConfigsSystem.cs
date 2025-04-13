using Entitas;

namespace Core
{
    internal class InitConfigsSystem : IInitializeSystem
    {  
        public void Initialize()
        {
            ConfigsManager.LoadConfigs();
        }
    }
}