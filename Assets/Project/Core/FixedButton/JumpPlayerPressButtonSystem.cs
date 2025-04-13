using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FixedButton
{
    internal class JumpPlayerPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;

        public JumpPlayerPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.Player);
        } 

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick.Added());
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isJumpPlayerButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {  
            foreach (var buttonEnt in entities)
            { 
                foreach (var playerEnt in _playerUnitGroup.GetEntities())
                {
                    if (playerEnt.stayOnGround.Value)
                    {
                        playerEnt.AddJump(Vector3.up * Mathf.Sqrt(2f * Mathf.Abs(Physics.gravity.y) * ConfigsManager.PlayerConfig.JumpHeight));
                        playerEnt.ReplaceStayOnGround(false);
                    }  
                } 
            } 
        } 
    }
}