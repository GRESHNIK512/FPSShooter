using Entitas;
using System.Collections.Generic;  

namespace Button
{
    internal class ClearButtonClickSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;

        public ClearButtonClickSystem(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts;
        } 

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.trigTryPlayerClick.Value;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttoEnt in entities)
            { 
                buttoEnt.ReplaceTrigTryPlayerClick(false);  
            }
        } 
    }
}