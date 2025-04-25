using Entitas; 

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
            Add(new DefaultItemToBackpackSystem(contexts));

            Add(new CalculateMassOnEquipmentSystem(contexts));
            Add(new TryAddEquipmentItemToBackPackSystem(contexts));

            Add(new ChangeWeaponInventoryPlayerSystem(contexts));
            Add(new SelectWeaponSlotSystem(contexts));
            Add(new ChageSelectPlayerWeapon(contexts));

            Add(new SitControlPlayerSystem(contexts)); 
            Add(new PlayerRotationCameraSystem(contexts));

            Add(new BotRotateSystem(contexts));
            Add(new ControlDistanceForShootSystem(contexts)); 
            Add(new BotAgroExecuteSystem(contexts)); 
           
            Add(new ShootExecuteSystem(contexts));
            Add(new MagazineAmmoCountChangePlayerSystem(contexts));
            Add(new TimeReloadChangePlayerSystem(contexts));
            Add(new ReloadingChangePlayerSystem(contexts));

            Add(new ShootBotFireWeaponSystem(contexts));
            Add(new ShootPlayerFireWeaponSystem(contexts));

            Add(new HpControlDeadSystem(contexts));
            Add(new PlayerHpTransferToUiSystem(contexts));
            
            Add(new DeadUnitSystem(contexts));

            Add(new UnloadLevelSystem(contexts));  
        }
    }
}