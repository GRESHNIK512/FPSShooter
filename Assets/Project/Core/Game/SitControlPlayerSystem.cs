using DG.Tweening;
using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class SitControlPlayerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;

        public SitControlPlayerSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SitDown);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var playerEnt in entities)
            {
                var sitHeight = ConfigsManager.PlayerConfig.SitHeight;
                var delay = ConfigsManager.PlayerConfig.SitDownDelay;

                float targetCapsuleHeight = playerEnt.sitDown.Value ?
                    playerEnt.caplsuleOriginalHeight.Value - sitHeight : playerEnt.caplsuleOriginalHeight.Value;
                Vector3 targetCameraPos = playerEnt.sitDown.Value ?
                    playerEnt.cameraOriginalPosition.Value - (sitHeight * Vector3.up) : playerEnt.cameraOriginalPosition.Value;  

                DOTween.To(() => playerEnt.caplsuleHeight.Value, x => playerEnt.ReplaceCaplsuleHeight(x), targetCapsuleHeight, delay)
                    .SetEase(Ease.OutQuad); 

                DOTween.To(() => playerEnt.cameraPosition.Value, x => playerEnt.ReplaceCameraPosition(x), targetCameraPos, delay)
                    .SetEase(Ease.OutQuad);
            }
        }
    }
}