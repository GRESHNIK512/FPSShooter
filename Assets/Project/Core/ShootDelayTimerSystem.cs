using Entitas; 
using UnityEngine;

namespace Game
{
    internal class ShootDelayTimerSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _shootDelayGroup;

        public ShootDelayTimerSystem(Contexts contexts)  
        {
            _context = contexts;
            _shootDelayGroup = _context.game.GetGroup(GameMatcher.ShootingDelay);
        }

        public void Execute()
        {
            foreach (var weaponEnt in _shootDelayGroup.GetEntities())
            {
                var nowDelay = weaponEnt.shootingDelay.Value;
                var newDelay = nowDelay - Time.deltaTime;

                if (newDelay > 0) weaponEnt.ReplaceShootingDelay(newDelay);
                else
                {
                    weaponEnt.RemoveShootingDelay();
                    //Debug.Log("EndShootingDelay= " + Time.time);
                }
            }
        }
    }
}