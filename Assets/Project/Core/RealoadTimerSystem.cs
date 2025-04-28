using Entitas;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
                if (!weaponEnt.isSelect || !weaponEnt.hasShootingDelay || weaponEnt.shootingDelay.Value > 0) continue;

                var nowReloadinTime = weaponEnt.reloading.Value;
                
                if (nowReloadinTime == 0) continue;
                
                var newReloadingTime = nowReloadinTime - Time.deltaTime;

                if (newReloadingTime > 0) 
                    weaponEnt.ReplaceReloading(newReloadingTime);
                else 
                {
                    weaponEnt.ReplaceMagazineAmmo(weaponEnt.magazineSize.Value);
                    weaponEnt.ReplaceReloading(0); 
                } 
            }
        }
    }
}