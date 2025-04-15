using Entitas;
using System.Collections.Generic;

namespace Core
{
    internal class TimersAddDestroyEntSysten : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public TimersAddDestroyEntSysten(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Timer.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var timerEnt in entities)
            {
                timerEnt.AddOriginalTimeDelay(timerEnt.time.Value);
                timerEnt.isDestroyOnEndLevel = true; 
            }
        }
    }
}