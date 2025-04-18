using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    internal class SitDownPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;

        public SitDownPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit, GameMatcher.Player));
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick.Added());
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isSitDownButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttoEnt in entities)
            {
                foreach (var playerEnt in _playerUnitGroup.GetEntities())
                {
                    if (!playerEnt.sitDown.Value) 
                        playerEnt.ReplaceSitDown(true); //sit
                    else if (!HaveHeadObsticale(playerEnt)) //up
                    {
                        playerEnt.ReplaceSitDown(false);
                    }
                } 
            }
        }

        private bool HaveHeadObsticale(GameEntity playerEnt)
        {
            float radius = playerEnt.capsuleCollider.Value.radius;
            float originalHeight = playerEnt.caplsuleOriginalHeight.Value;
            float sitHeight = ConfigsManager.PlayerConfig.SitHeight;

            //Вычисляем точки для ниж сферы
            Vector3 point2 = playerEnt.transform.Value.position + playerEnt.capsuleCollider.Value.center -
                Vector3.up * ((originalHeight - sitHeight) / 2 - radius);

            // Проверяем Raycast между точками капсулы при полном росте
            bool haveObsticale = (Physics.CapsuleCast(
                point2,
                point2,
                radius,
                Vector3.up,
                originalHeight,
                ConfigsManager.PlayerConfig.GroundLayerMask));

            //DrawSphere(point2, radius, Color.red, 5f);
            //Debug.DrawLine(point2, point2, Color.cyan, 5f);

            //Debug.Log(haveObsticale);
            return haveObsticale;
        }

        //public void DrawSphere(Vector3 center, float radius, Color color, float duration)
        //{
        //    int segments = 20;
        //    float angle = 0f;

        //    Vector3 lastPoint = center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

        //    for (int i = 1; i <= segments; i++)
        //    {
        //        angle += 2 * Mathf.PI / segments;
        //        Vector3 nextPoint = center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
        //        Debug.DrawLine(lastPoint, nextPoint, color, duration);
        //        lastPoint = nextPoint;

        //        // Вертикальные окружности
        //        nextPoint = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        //        Debug.DrawLine(lastPoint, nextPoint, color, duration);
        //        lastPoint = nextPoint;

        //        nextPoint = center + new Vector3(0, Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        //        Debug.DrawLine(lastPoint, nextPoint, color, duration);
        //        lastPoint = nextPoint;
        //    }
        //}
    }
}