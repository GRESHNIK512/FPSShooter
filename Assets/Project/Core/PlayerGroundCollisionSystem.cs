using Entitas;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FixedGame
{
    internal class PlayerGroundCollisionSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;
        private RaycastHit[] hit = new RaycastHit[15];

        public PlayerGroundCollisionSystem(Contexts contexts) : base(contexts.ui)
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
                    var pos = playerEnt.transform.Value.position + playerEnt.capsuleCollider.Value.center;

                    int countGround = Physics.SphereCastNonAlloc(
                       pos,
                       playerEnt.capsuleCollider.Value.radius,
                       Vector3.down,
                       hit,
                       playerEnt.capsuleCollider.Value.height / 2 + 0.05f,
                       ConfigsManager.PlayerConfig.GroundLayerMask);

                    bool isGrounded = countGround > 0;

                    //Debug.DrawRay(pos, Vector3.down * (playerEnt.capsuleCollider.Value.height / 2 + 0.05f), isGrounded ? Color.green : Color.red, 5f);
                    playerEnt.ReplaceStayOnGround(isGrounded); 
                } 
            }
        }
    }
}