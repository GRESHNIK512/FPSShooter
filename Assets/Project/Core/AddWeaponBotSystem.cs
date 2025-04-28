using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class AddWeaponBotSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private WeaponConfig _weaponConfig;   

        public AddWeaponBotSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Unit);
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var unitEnt in entities)
            {
                if (_weaponConfig == null) _weaponConfig = ConfigsManager.WeaponConfig;

                var indexWeapon = Random.Range(0, _weaponConfig.Weapons.Length);
                var weaponSetting = _weaponConfig.Weapons[indexWeapon];

                var weapon = PoolService.Instance.GetObjectFromPool<Weapon>(
                    weaponSetting.Type, 
                    unitEnt.unitWeaponTransform.Value, 
                    unitEnt.unitWeaponTransform.Value.position);
                  
                GameEntity weaponEnt = CreateWeapon(weapon, weaponSetting);

                var inventoryEnt = _context.game.GetEntityWithId(unitEnt.inventoryId.Value[0]);
                inventoryEnt.AddWeaponsId(new List<int> { weaponEnt.id.Value });
            }
        }

        private GameEntity CreateWeapon(Weapon weapon, WeaponSettings weaponSetting)
        {
            weapon.Init();
            var weaponEnt = weapon.GameEntity;

            weaponEnt.AddDefaultFireMode(weaponSetting.DefaultFireMode);
            weaponEnt.AddTimeReload(weaponSetting.TimeReaload);
            weaponEnt.AddTimeShootDelay(weaponSetting.TimeShootDelay);
            weaponEnt.AddMagazineSize(weaponSetting.MagazineSize);
            weaponEnt.AddAmmoType(weaponSetting.AmmoType);
            weaponEnt.AddDamageFalloffCurve(weaponSetting.DamageFalloffCurve);
            weaponEnt.AddDistanceShoot(weaponSetting.DistanceShoot);
            //weaponEnt.AddSetLocalPosition(Vector3.zero);
            weaponEnt.AddReloading(1);

            return weaponEnt;
        }
    }
}