using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class PlayerHpTransferToUiSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _gameLevelGroup;

        public PlayerHpTransferToUiSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
            _gameLevelGroup = _context.ui.GetGroup(UiMatcher.GameLevelWindow);
        } 

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Hp);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var playerEnt in entities) 
            {
                foreach (var windowEnt in _gameLevelGroup.GetEntities())
                {
                    windowEnt.ReplaceHp(playerEnt.hp.Value);
                }
            }
        } 
    }
}