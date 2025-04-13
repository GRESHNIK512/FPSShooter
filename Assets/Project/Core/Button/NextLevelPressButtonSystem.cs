using Entitas;
using System.Collections.Generic;

namespace Button
{
    internal class NextLevelPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context; 

        public NextLevelPressButtonSystem(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts; 
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isNextLevelButton;
        } 
       
        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttonEnt in entities) 
            {
                var levelManagerEnt = _context.game.levelManagerEntity;

                levelManagerEnt.isNeedLoadNextLevelAfterUnload = true;
                levelManagerEnt.isLevelUnload = true; 
            }
        } 
    }
}