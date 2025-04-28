using Entitas; 

namespace Game
{
    internal class ShootExecuteSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _tryShootGroup;

        public ShootExecuteSystem(Contexts contexts)
        {
            _context = contexts;
            _tryShootGroup = _context.game.GetGroup(GameMatcher.TryShoot);
        }

        public void Execute()
        {
            foreach (var weaponEnt in _tryShootGroup.GetEntities())
            {
                if ((weaponEnt.hasShootingDelay && weaponEnt.shootingDelay.Value != 0) || 
                    (weaponEnt.hasReloading && weaponEnt.reloading.Value != 0) || 
                    weaponEnt.magazineAmmo.Value == 0) continue;

                if (weaponEnt.isFireWeapon)
                {
                    var nowAmmoInMagazine = weaponEnt.magazineAmmo.Value;
                    var newAmmo = nowAmmoInMagazine - 1;

                    weaponEnt.ReplaceMagazineAmmo(newAmmo);

                    weaponEnt.ReplaceShootingDelay(weaponEnt.timeShootDelay.Value);
                    if (newAmmo == 0)
                        weaponEnt.ReplaceReloading(weaponEnt.timeReload.Value);
                }

                weaponEnt.isShoot = true;

                if (weaponEnt.defaultFireMode.Value == FireMode.Single && weaponEnt.isPlayer || !weaponEnt.isPlayer)
                    weaponEnt.isTryShoot = false;

            }
        }
    }
}