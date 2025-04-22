using Entitas;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class ShootPlayerFireWeaponSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;
       
        private Ray _ray = new Ray();
        private RaycastHit[] _hitsBuffer = new RaycastHit[10];
        private Transform _camTranform;

        public ShootPlayerFireWeaponSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit, GameMatcher.Player));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Shoot);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isFireWeapon &&
                   entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var weaponEnt in entities)
            {
                SetPositionAndDirForRaycast(weaponEnt);

                // Проверяем попадание в объект на нужном слое
                int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, weaponEnt.distanceShoot.Value, ConfigsManager.PlayerConfig.ShootLayerMasks);

                if (hitsCount == 0) continue;

                float minDist = float.MaxValue;
                int targetIndexHit = -1;

                for (int i = 0; i < hitsCount; i++)
                {
                    var distance = (_ray.origin - _hitsBuffer[i].point).sqrMagnitude;
                    if (distance > minDist) continue;

                    minDist = distance;
                    targetIndexHit = i;
                }

                var targetCollider = _hitsBuffer[targetIndexHit].collider;
                if ((1 << targetCollider.gameObject.layer & ConfigsManager.PlayerConfig.ShootTargetLayerMask.value) == 0) continue;

                if (!targetCollider.TryGetComponent<BodyPart>(out var bodyPart)) continue;

                var hitEntity = bodyPart.UnitEntity;

                if (hitEntity.isDead) continue;  
                
                var damage = weaponEnt.damageFalloffCurve.Value.Evaluate(Mathf.Sqrt(minDist));  

                float damageMultiplier = GetDamageMultiplier(bodyPart.PartType);
                var newHp = hitEntity.hp.Value - damage * damageMultiplier;

                hitEntity.ReplaceHp(Mathf.Max(newHp, 0));
            }
        }

        private void SetPositionAndDirForRaycast(GameEntity weaponEnt)
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
            Debug.DrawRay(_ray.origin, _ray.direction * weaponEnt.distanceShoot.Value, Color.green, 0.1f);
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
    }
}