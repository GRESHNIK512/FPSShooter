using Entitas;
using System.Collections.Generic;

namespace Core
{
    internal class RefreshStatusWindowSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;

        public RefreshStatusWindowSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigRefreshStatusWindowDelay);
        }

        protected override bool Filter(UiEntity entity)
        {
            return true;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var e in entities)
            {
                var timerThrowEnt = _context.game.CreateEntity();
                timerThrowEnt.isTimer = true;
                timerThrowEnt.AddTime(e.trigRefreshStatusWindowDelay.Value);
                timerThrowEnt.isRefreshWindowStatusTimer = true;

                e.Destroy();
            }
        }
    }
}