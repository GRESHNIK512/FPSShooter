using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class AddWeaponBotSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private WeaponConfig _weaponConfig;

        private WeaponSettings _weaponSetting;
        private Weapon _weapon;
        private GameEntity _weaponEnt;

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

                var indexWeapon = UnityEngine.Random.Range(0, _weaponConfig.Weapons.Length);
                _weaponSetting = _weaponConfig.Weapons[indexWeapon];

                _weapon = _weaponSetting.WeaponType switch
                {
                    WeaponType.Pistol => PoolService.Instance.GetObjectFromPool<Pistol>(unitEnt.unitWeaponTransform.Value),
                    WeaponType.M16 => PoolService.Instance.GetObjectFromPool<M16>(unitEnt.unitWeaponTransform.Value),
                    _ => null
                };

                if (_weapon == null)
                {
                    Debug.LogError("Add WeaponType in AddWeaponBotSystem");
                    continue;
                }

                _weapon.Init();
                _weaponEnt = _weapon.GameEntity;

                _weaponEnt.AddWeaponType(_weaponSetting.WeaponType);
                _weaponEnt.AddSupportedFireModes(_weaponSetting.SupportedFireModes);
                _weaponEnt.AddDefaultFireMode(_weaponSetting.DefaultFireMode);
                _weaponEnt.AddBurstCount(_weaponSetting.BurstCount);
                _weaponEnt.AddTimeReload(_weaponSetting.TimeReaload);
                _weaponEnt.AddShootingDelay(_weaponSetting.ShootingDelay);
                _weaponEnt.AddMagazineSize(_weaponSetting.MagazineSize);
                _weaponEnt.AddAmmoType(_weaponSetting.AmmoType);
                _weaponEnt.AddDamageFalloffCurve(_weaponSetting.DamageFalloffCurve);
                _weaponEnt.AddDistanceShoot(_weaponSetting.DistanceShoot);
            }
        }
    }
}