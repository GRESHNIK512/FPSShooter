using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class HpControlDeadSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public HpControlDeadSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Hp);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        } 
      
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities) 
            {
                if (entity.hp.Value<=0) entity.isDead = true;
            }
        } 
    }
}