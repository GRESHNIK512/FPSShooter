using Entitas;
using System.Collections.Generic; 
using UnityEngine;

namespace Game
{
    internal class ShootBotFireWeaponSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _unitLiveGroup;

        private RaycastHit[] _hitsBuffer = new RaycastHit[10];
        private Ray _ray = new Ray(); 

        public ShootBotFireWeaponSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
            _unitLiveGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit).NoneOf(GameMatcher.Dead, GameMatcher.Player));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Shoot);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isFireWeapon && 
                  !entity.isPlayer;
        } 

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var weaponEnt in entities) 
            {  
                var unitEnt = GetUnitByWeaponId(weaponEnt.id.Value);
              
                if (unitEnt == null) continue;
               
                _ray.origin = weaponEnt.transform.Value.position; 
                _ray.direction = (unitEnt.shootPoint.Value.position - _ray.origin).normalized;
                var dist = Vector3.Distance(_ray.origin, unitEnt.shootPoint.Value.position);
                Debug.DrawRay(_ray.origin, _ray.direction * dist, Color.green, weaponEnt.shootingDelay.Value); 
              
                int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, dist + 0.05f, ConfigsManager.BotConfig.ShootTargetLayerMask); 
                
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
                if ((1 << targetCollider.gameObject.layer & ConfigsManager.BotConfig.ShootTargetLayerMask.value) == 0) continue;

                if (!targetCollider.TryGetComponent<BodyPart>(out var bodyPart)) continue;
                var hitEntity = bodyPart.UnitEntity;

                if (hitEntity.isDead) continue;  
                
                var damage = Random.Range(1f, 1.5f);
                //var damage = weaponEnt.damageFalloffCurve.Value.Evaluate(dist);
                float damageMultiplier = GetDamageMultiplier(bodyPart.PartType); 
                
                var newHp = hitEntity.hp.Value - damage * damageMultiplier; 
                hitEntity.ReplaceHp(Mathf.Max(newHp, 0));
            }
        }

        private GameEntity GetUnitByWeaponId(int weaponId) 
        {
            GameEntity targetUnit = null;

            foreach (var unitEnt in _unitLiveGroup.GetEntities())
            {
                var inventoryEnt = _context.game.GetEntityWithId(unitEnt.inventoryId.Value[0]);

                if (inventoryEnt.hasWeaponsId && inventoryEnt.weaponsId.Value.Contains(weaponId))
                {
                    targetUnit = unitEnt; 
                    break;
                }
            }

            return targetUnit;
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