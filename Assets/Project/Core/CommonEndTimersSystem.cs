using Entitas; 
using UnityEngine;

namespace Core
{
    internal class CommonEndTimersSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _timersGroup;
        private float _newTime;
        
        public CommonEndTimersSystem(Contexts contexts)
        {
            _context = contexts;
            _timersGroup = contexts.game.GetGroup(GameMatcher.Timer);
        }

        public void Execute()
        {  
            foreach (var timerEnt in _timersGroup.GetEntities())
            {
                if (timerEnt.isTimerOnPause) continue;
                
                _newTime = timerEnt.time.Value - Time.deltaTime;
                if (_newTime < 0f)
                    timerEnt.isTrigTimerEnd = true;
                else 
                    timerEnt.ReplaceTime(_newTime);
            }
        }
    }
}
