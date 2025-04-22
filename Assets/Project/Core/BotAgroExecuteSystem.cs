using Entitas;
using UnityEngine;

namespace Game
{
    internal class BotAgroExecuteSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _agroBotGroup;

        public BotAgroExecuteSystem(Contexts contexts) 
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
               
                if (nowTimer <= 0)
                    unitEnt.RemoveAgroShootingTimer();  
                
                weaponEnt.isTryShoot = true; 
            }
        }
    }
}
