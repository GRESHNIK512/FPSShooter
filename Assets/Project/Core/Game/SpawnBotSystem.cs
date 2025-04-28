using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class SpawnBotSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _spawnGroup;
        private IGroup<GameEntity> _levelGroup;

        public SpawnBotSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _spawnGroup = _context.game.GetGroup(GameMatcher.Spawner);
            _levelGroup = _context.game.GetGroup(GameMatcher.Level);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.StartLoadLevel.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var levelManagerEnt in entities)
            {
                foreach (var levelEnt in _levelGroup.GetEntities()) 
                {
                    foreach (var spawnEnt in _spawnGroup.GetEntities())
                    {
                        if (spawnEnt.owner.Value == Owner.Bot) 
                        {
                            var botView = PoolService.Instance.GetObjectFromPool<BotView>(levelEnt.transform.Value, spawnEnt.setPosition.Value); 
                            
                            botView.Init();
                            //botView.GameEntity.ReplaceSetPosition(spawnEnt.setPosition.Value);
                            botView.GameEntity.ReplaceUnitRotation(new Vector3(0f, 180f, 0f));
                        }
                    }
                }
            }
        }
    } 
}