using Entitas;
using UnityEngine;

namespace Game
{
    internal class BotRotateSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _enemyGroup;

        public BotRotateSystem(Contexts contexts)
        {
            _context = contexts;
            _enemyGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit).NoneOf(GameMatcher.Dead, GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var enemyEnt in _enemyGroup.GetEntities())
            {
                if (!enemyEnt.hasShootPoint || enemyEnt.shootPoint.Value == null) continue;
                // Получаем текущую позицию и позицию цели
                var botPos = enemyEnt.transform.Value.position + Vector3.up;
                var pointPos = enemyEnt.shootPoint.Value.position;

                // Вычисляем направление к цели
                var direction = pointPos - botPos;   

                // Применяем поворот (например, записываем в компонент)
                enemyEnt.ReplaceUnitRotation(Quaternion.LookRotation(direction).eulerAngles); 
            }
        }
    }
}