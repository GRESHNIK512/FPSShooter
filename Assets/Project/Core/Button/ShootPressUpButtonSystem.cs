using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    internal class ShootPressUpButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _tryShootGroup;

        public ShootPressUpButtonSystem(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts;
            _tryShootGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.TryShoot, GameMatcher.Player, GameMatcher.Weapon));
        } 

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigButtonUp);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isShootButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttonEnt in entities) 
            {
                foreach (var weaponEnt in _tryShootGroup.GetEntities())
                {
                    //Debug.Log("UpClick + DeleteTryShoot");
                    weaponEnt.isTryShoot = false;
                }
            }
        } 
    }
}