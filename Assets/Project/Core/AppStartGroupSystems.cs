using Entitas;

namespace Core
{
    internal class AppStartGroupSystems : Systems
    {
        internal AppStartGroupSystems(Contexts contexts)
        {
            Add(new InitConfigsSystem());
            Add(new InitClientDataSystem(contexts));  
            Add(new InitInputSystem(contexts));
            Add(new LevelManagerInitSystem(contexts));
            Add(new LoadUiSceneSystem());
        }
    }
}