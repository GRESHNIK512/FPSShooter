using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class AddWeaponPlayerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context; 
        private List<int> _weaponsIdPlayer = new(); 

        public AddWeaponPlayerSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
        }
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Unit);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var unitEnt in entities)
            {  
                foreach (var weaponInfo in ConfigsManager.WeaponConfig.Weapons)
                {
                    var weapon = PoolService.Instance.GetObjectFromPool<Weapon>(weaponInfo.WeaponType, unitEnt.unitWeaponTransform.Value);
                    
                    if (weapon == null)
                    {
                        Debug.LogError("not Found WeaponType in AddWeaponBotSystem");
                        continue;
                    }

                    GameEntity weaponEnt = CreateWeapon(weapon, weaponInfo);
                    _weaponsIdPlayer.Add(weaponEnt.id.Value);
                }      

                var inventoryEnt = _context.game.GetEntityWithId(unitEnt.inventoryId.Value[0]); 
                inventoryEnt.AddWeaponsId(new (_weaponsIdPlayer));
                inventoryEnt.isPlayer = true;

                _weaponsIdPlayer.Clear();
            }
        }

        private GameEntity CreateWeapon(Weapon weapon, WeaponSettings weaponSetting)
        {
            weapon.Init();
            var weaponEnt = weapon.GameEntity;

            weaponEnt.AddWeaponType(weaponSetting.WeaponType);
            //weaponEnt.AddSupportedFireModes(weaponSetting.SupportedFireModes);
            weaponEnt.AddDefaultFireMode(weaponSetting.DefaultFireMode);
            //weaponEnt.AddBurstCount(weaponSetting.BurstCount);
            weaponEnt.AddTimeReload(weaponSetting.TimeReaload);
            weaponEnt.AddTimeShootDelay(weaponSetting.TimeShootDelay);
            weaponEnt.AddMagazineSize(weaponSetting.MagazineSize);
            weaponEnt.AddAmmoType(weaponSetting.AmmoType);
            weaponEnt.AddDamageFalloffCurve(weaponSetting.DamageFalloffCurve);
            weaponEnt.AddDistanceShoot(weaponSetting.DistanceShoot);
            weaponEnt.AddSetLocalPosition(Vector3.zero);

            weaponEnt.isPlayer = true;
            weaponEnt.isSelect = true;

            return weaponEnt;
        }
    }
}