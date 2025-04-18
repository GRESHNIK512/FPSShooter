using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class PlayerRotationCameraSystem : ReactiveSystem<InputEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;
        private float rotationX = 0;
        private float rotationY = 0; 

        public PlayerRotationCameraSystem(Contexts contexts) : base(contexts.input)
        {
            _context = contexts;
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit,GameMatcher.Player));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TouchDeltaPosition);
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEnt in entities)
            { 
                // Инвертируем ось Y по желанию (можно поменять знак если нужно)
                rotationY += inputEnt.touchDeltaPosition.Value.x * ConfigsManager.PlayerConfig.Sensitivity * Time.deltaTime;
                rotationX -= inputEnt.touchDeltaPosition.Value.y * ConfigsManager.PlayerConfig.Sensitivity * Time.deltaTime;

                // Ограничиваем вертикальный поворот
                rotationX = Mathf.Clamp(rotationX, -80f, 80f);

                foreach (var playerEnt in _playerUnitGroup.GetEntities())
                {
                    // Применяем поворот
                    playerEnt.ReplaceUnitRotation(new Vector3(rotationX, rotationY, 0));
                } 
            }
        }
    }
}