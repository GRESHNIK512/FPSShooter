﻿using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    internal class ShootPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;

        private RaycastHit[] _hitsBuffer = new RaycastHit[10];
        private Ray _ray = new();
        private Transform _camTranform;

        public ShootPressButtonSystem(Contexts contexts) : base(contexts.ui)
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
            return entity.isShootButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttoEnt in entities)
            {
                //SetPositionAndDirForRaycast();

                //// Проверяем попадание в объект на нужном слое
                //int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, ConfigsManager.PlayerConfig.MaxDistanceRay, ConfigsManager.PlayerConfig.ShootLayerMasks);

                //if (hitsCount == 0) continue;

                //float minDist = float.MaxValue;
                //int targetIndexHit = -1;

                //for (int i = 0; i < hitsCount; i++)
                //{
                //    var distance = (_ray.origin - _hitsBuffer[i].point).sqrMagnitude;
                //    if (distance > minDist) continue;

                //    minDist = distance;
                //    targetIndexHit = i;
                //}

                //var targetCollider = _hitsBuffer[targetIndexHit].collider;
                //if ((1 << targetCollider.gameObject.layer & ConfigsManager.PlayerConfig.ShootTargetLayerMask.value) == 0) continue;

                //if (!targetCollider.TryGetComponent<BodyPart>(out var bodyPart)) continue;

                //var hitEntity = bodyPart.UnitEntity;

                //if (hitEntity.isDead) continue;

                //var damage = 50f;
                //float damageMultiplier = GetDamageMultiplier(bodyPart.PartType);
                //var newHp = hitEntity.hp.Value - damage * damageMultiplier;

                //hitEntity.ReplaceHp(Mathf.Max(newHp, 0));
            }
        }

        private float GetDamageMultiplier(BodyPartType partType)
        {
            switch (partType)
            {
                case BodyPartType.Head: return 2f; // x2 урон по голове
                case BodyPartType.Body: return 1f; // обычный урон 
                default: return 1f;
            }
        }

        private void SetPositionAndDirForRaycast()
        {
            if (_camTranform == null)
            {
                foreach (var playerEnt in _playerUnitGroup.GetEntities())
                {
                    _camTranform = playerEnt.camera.Value.transform;
                }
            }

            _ray.origin = _camTranform.transform.position;
            _ray.direction = _camTranform.transform.forward;
            //Debug.DrawRay(_ray.origin, _ray.direction * ConfigsManager.PlayerConfig.MaxDistanceRay, Color.green, 5f);
        }
    }
}