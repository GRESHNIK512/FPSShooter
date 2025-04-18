using Entitas;
using Zenject;

namespace Game
{
    internal class GameControlSystems : Systems
    { 
        internal GameControlSystems(Contexts contexts)
        {
            Add(new ShootDelayTimerSystem(contexts));
            Add(new RealoadTimerSystem(contexts));

            Add(new SpawnPlayerSystem(contexts));
            Add(new SpawnBotSystem(contexts));

            Add(new CreateUnitInventorySystem(contexts));
            Add(new AddWeaponPlayerSystem(contexts));
            Add(new AddWeaponBotSystem(contexts)); 

            Add(new SitControlPlayerSystem(contexts)); 
            Add(new PlayerRotationCameraSystem(contexts));

            Add(new BotRotateSystem(contexts));
            Add(new ControlDistanceForShootSystem(contexts)); 
            Add(new BotAgroSystem(contexts));
            Add(new ShootFireWeaponSystem(contexts));  

            Add(new HpControlDeadSystem(contexts));
            Add(new PlayerHpTransferToUiSystem(contexts));
            
            Add(new DeadUnitSystem(contexts));

            Add(new UnloadLevelSystem(contexts));  
        }
    }
}