using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class CreateUnitInventorySystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public CreateUnitInventorySystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
        } 

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Unit);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var unitEnt in entities) 
            {
                var inventoryEnt = _context.game.CreateEntity();
                inventoryEnt.isInventory = true;
                inventoryEnt.AddId(inventoryEnt.creationIndex);

                unitEnt.AddInventoryId(new List<int> { inventoryEnt.id.Value });
            }
        } 
    }
}