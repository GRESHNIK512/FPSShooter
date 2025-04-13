using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class SpawnPlayerSystem : ReactiveSystem<GameEntity>
    { 
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;
        private IGroup<GameEntity> _spawnGroup;
        private IGroup<GameEntity> _levelGroup;

        public SpawnPlayerSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;

            _playerUnitGroup = _context.game.GetGroup(GameMatcher.Player);
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
                if (_playerUnitGroup.count == 0)
                {
                    foreach (var levelEnt in _levelGroup.GetEntities())
                    {
                        var playerView = PoolService.Instance.GetObjectFromPool<PlayerView>(levelEnt.transform.Value);
                        playerView.Init();
                    }
                }  

                foreach (var playerEnt in _playerUnitGroup.GetEntities())
                { 
                    foreach (var spawnEnt in _spawnGroup.GetEntities())
                    {
                        if (spawnEnt.owner.Value == Owner.Player)
                        {
                            playerEnt.ReplaceSetPosition(spawnEnt.setPosition.Value);
                            break;
                        }
                    }
                } 
            }
        }
    }
}