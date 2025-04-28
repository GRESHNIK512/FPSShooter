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
                foreach (var weaponSetting in ConfigsManager.WeaponConfig.Weapons)
                {
                    var weapon = PoolService.Instance.GetObjectFromPool<Weapon>(weaponSetting.Type, unitEnt.unitWeaponTransform.Value);  

                    GameEntity weaponEnt = CreateWeapon(weapon, weaponSetting);
                    _weaponsIdPlayer.Add(weaponEnt.id.Value);
                }      

                var inventoryEnt = _context.game.GetEntityWithId(unitEnt.inventoryId.Value[0]);
                inventoryEnt.isPlayer = true;
                inventoryEnt.AddWeaponsId(new (_weaponsIdPlayer)); 

                _weaponsIdPlayer.Clear();
            }
        }

        private GameEntity CreateWeapon(Weapon weapon, WeaponSettings weaponSetting)
        {
            weapon.Init();
            var weaponEnt = weapon.GameEntity;

            weaponEnt.isPlayer = true;  
            
            weaponEnt.AddDefaultFireMode(weaponSetting.DefaultFireMode); 
            weaponEnt.AddTimeReload(weaponSetting.TimeReaload);
            weaponEnt.AddTimeShootDelay(weaponSetting.TimeShootDelay);
            weaponEnt.AddMagazineSize(weaponSetting.MagazineSize);
            weaponEnt.AddAmmoType(weaponSetting.AmmoType);
            weaponEnt.AddDamageFalloffCurve(weaponSetting.DamageFalloffCurve);
            weaponEnt.AddDistanceShoot(weaponSetting.DistanceShoot);
            weaponEnt.AddSetLocalPosition(Vector3.zero);

            weaponEnt.AddMagazineAmmo(weaponEnt.magazineSize.Value); 
            return weaponEnt;
        }
    }
}