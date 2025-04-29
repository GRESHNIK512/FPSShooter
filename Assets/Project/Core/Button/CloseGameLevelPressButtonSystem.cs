using Entitas;
using System.Collections.Generic;
using UnityEngine; 

namespace Button
{
    internal class CloseGameLevelPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _buttonMainMenuGroup;

        public CloseGameLevelPressButtonSystem(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts;
            _buttonMainMenuGroup = _context.ui.GetGroup(UiMatcher.MainMenuButton);
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isCloseGameLevelButton && entity.trigTryPlayerClick.Value;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttonEnt in entities)
            { 
                _context.game.levelManagerEntity.isRepeatLevel = true;

                foreach (var mainMenuButtonEnt in _buttonMainMenuGroup.GetEntities()) 
                {
                    mainMenuButtonEnt.ReplaceTrigTryPlayerClick(true);
                } 
            }
        }
    }
}