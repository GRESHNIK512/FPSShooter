using Entitas;
using System.Collections.Generic;

namespace Core
{
    internal class EndRefreshWindowTimerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _windowGroup; 

        public EndRefreshWindowTimerSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _windowGroup = _context.ui.GetGroup(UiMatcher.Window); 
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TrigTimerEnd.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isRefreshWindowStatusTimer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var dEnt in entities)
            {
                foreach (var windowEnt in _windowGroup.GetEntities())
                { 
                    windowEnt.ReplaceCanvasEnable(windowEnt.isShowOnlyThisWindow);
                    windowEnt.ReplaceGraphicRaycasterEnable(windowEnt.isShowOnlyThisWindow); 
                }
            }
        }
    }
}