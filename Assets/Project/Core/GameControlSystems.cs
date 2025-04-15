using Entitas;

namespace Game
{
    internal class GameControlSystems : Systems
    { 
        internal GameControlSystems(Contexts contexts)
        { 
            Add(new SpawnPlayerSystem(contexts));
            Add(new SpawnBotSystem(contexts));

            Add(new CreateUnitInventorySystem(contexts));
            Add(new AddWeaponBotSystem(contexts));

            Add(new SitControlPlayerSystem(contexts)); 
            Add(new PlayerRotationCameraSystem(contexts));

            Add(new ControlDistanceForShootSystem(contexts));
            Add(new BotRotateSystem(contexts));

            Add(new HpControlDeadSystem(contexts));
            Add(new PlayerHpTransferToUiSystem(contexts));
            
            Add(new DeadUnitSystem(contexts));

            Add(new UnloadLevelSystem(contexts));  
        }
    }
}