using Entitas;
using UnityEngine;

namespace Game
{
    internal class BotAgroSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _agroBotGroup;

        public BotAgroSystem(Contexts contexts) 
        {
            _context = contexts;
            _agroBotGroup = _context.game.GetGroup(GameMatcher.AgroShootingTimer);
        }   

        public void Execute()
        {
            foreach (var unitEnt in _agroBotGroup.GetEntities())
            {
                var nowTimer = unitEnt.agroShootingTimer.Value;
                nowTimer -= Time.deltaTime;
                unitEnt.ReplaceAgroShootingTimer(nowTimer);

                var inventoryEnt = _context.game.GetEntityWithId(unitEnt.inventoryId.Value[0]);
                var weaponEnt = _context.game.GetEntityWithId(inventoryEnt.weaponsId.Value[0]);
                
                if (!weaponEnt.hasReloading && !weaponEnt.hasShootingDelay) 
                { 
                    if (weaponEnt.magazineAmmo.Value > 0) 
                    {  
                        weaponEnt.isShoot = true;
                        //Debug.Log("StartShootTime= " + Time.time);
                    }
                }  

                if (nowTimer > 0) continue;
                    unitEnt.RemoveAgroShootingTimer();
            }
        }
    }
}
