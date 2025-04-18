using Entitas;
using UnityEngine;

namespace Game
{
    internal class RealoadTimerSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _reloadingGroup;

        public RealoadTimerSystem(Contexts contexts)
        {
            _context = contexts;
            _reloadingGroup = _context.game.GetGroup(GameMatcher.Reloading);
        }

        public void Execute()
        {
            foreach (var weaponEnt in _reloadingGroup.GetEntities())
            {
                if (weaponEnt.hasShootingDelay) continue;
               
                var nowReloadingTime = weaponEnt.reloading.Value;
                var newReloadingTime = nowReloadingTime - Time.deltaTime;

                if (newReloadingTime > 0) weaponEnt.ReplaceReloading(newReloadingTime);
                else
                {
                    weaponEnt.ReplaceMagazineAmmo(weaponEnt.magazineSize.Value);
                    weaponEnt.RemoveReloading();
                }
            }
        }
    }
}