using Entitas;
using System.Collections.Generic; 

namespace Game
{
    internal class CalculateMassOnEquipmentSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public CalculateMassOnEquipmentSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Count, GameMatcher.MassByOneItem));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEquipment;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var equipmetEnt in entities) 
            {  
                equipmetEnt.ReplaceMassResult(equipmetEnt.count.Value * equipmetEnt.massByOneItem.Value); 
            }
        } 
    }
}