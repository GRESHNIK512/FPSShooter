using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace FixedGame
{
    internal class PlayerIcreaseVelositySystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;

        public PlayerIcreaseVelositySystem(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts;
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit, GameMatcher.Player));
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.JoystickDirection);
        }

        protected override bool Filter(UiEntity entity)
        {
            return true;
        } 
       
        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var joysticEnt in entities)
            {
                foreach (var playerEnt in _playerUnitGroup.GetEntities())
                {
                    if (playerEnt.isDead) return;

                    var VelocityVector = new Vector3(
                        joysticEnt.joystickDirection.Value.x,
                        0,
                        joysticEnt.joystickDirection.Value.y);

                    VelocityVector = playerEnt.transform.Value.TransformDirection(VelocityVector);
                    VelocityVector *= ConfigsManager.PlayerConfig.MoveSpeed * Time.fixedDeltaTime;
                   
                    playerEnt.ReplaceVelocity(VelocityVector);
                } 
            }
        } 
    }
}