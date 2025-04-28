using Entitas;
using System.Collections.Generic;

namespace Button
{
    internal class MainMenuPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _windowGroup;   

        public MainMenuPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _windowGroup = _context.ui.GetGroup(UiMatcher.Window);
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isMainMenuButton && entity.trigTryPlayerClick.Value;
        } 

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttonEnt in entities)
            {
                _context.game.levelManagerEntity.isLevelUnload = true; 

                foreach (var windowEnt in _windowGroup.GetEntities())
                {
                    windowEnt.isShowOnlyThisWindow = windowEnt.isMainMenuWindow;
                }

                _context.ui.CreateEntity().AddTrigRefreshStatusWindowDelay(0f);
            }
        } 
    }
}