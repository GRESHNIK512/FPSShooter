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

                Weapon weapon = weaponSetting.WeaponType switch
                {
                    WeaponType.Pistol => PoolService.Instance.GetObjectFromPool<Pistol>(unitEnt.unitWeaponTransform.Value),
                    WeaponType.M16 => PoolService.Instance.GetObjectFromPool<M16>(unitEnt.unitWeaponTransform.Value),
                    _ => null
                };

                if (weapon == null)
                {
                    Debug.LogError("not Found WeaponType in AddWeaponBotSystem");
                    continue; 
                }

                GameEntity weaponEnt = CreateWeapon(weapon, weaponSetting);

                var inventoryEnt = _context.game.GetEntityWithId(unitEnt.inventoryId.Value[0]);
                inventoryEnt.AddWeaponsId(new List<int> { weaponEnt.id.Value });
            }
        }

        private GameEntity CreateWeapon(Weapon weapon, WeaponSettings weaponSetting)
        {
            weapon.Init();
            var weaponEnt = weapon.GameEntity;

            weaponEnt.AddWeaponType(weaponSetting.WeaponType);
            weaponEnt.AddSupportedFireModes(weaponSetting.SupportedFireModes);
            weaponEnt.AddDefaultFireMode(weaponSetting.DefaultFireMode);
            weaponEnt.AddBurstCount(weaponSetting.BurstCount);
            weaponEnt.AddTimeReload(weaponSetting.TimeReaload);
            weaponEnt.AddShootingDelay(weaponSetting.ShootingDelay);
            weaponEnt.AddMagazineSize(weaponSetting.MagazineSize);
            weaponEnt.AddAmmoType(weaponSetting.AmmoType);
            weaponEnt.AddDamageFalloffCurve(weaponSetting.DamageFalloffCurve);
            weaponEnt.AddDistanceShoot(weaponSetting.DistanceShoot);
            weaponEnt.AddMagazineAmmo(weaponSetting.MagazineSize);

            return weaponEnt;
        }
    }
}