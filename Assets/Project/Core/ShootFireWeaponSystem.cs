using Entitas;
using System.Collections.Generic; 
using UnityEngine;

namespace Game
{
    internal class ShootFireWeaponSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _unitLiveGroup;

        private RaycastHit[] _hitsBuffer = new RaycastHit[10]; 
        //private float _lastTime;

        public ShootFireWeaponSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
            _unitLiveGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit).NoneOf(GameMatcher.Dead));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Shoot);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isFireWeapon;
        } 

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var weaponEnt in entities) 
            { 
                var nowAmmoInMagazine = weaponEnt.magazineAmmo.Value;
                var newAmmo = nowAmmoInMagazine - 1;
                //Debug.Log("Shoot " + nowAmmoInMagazine + " " + (Time.time - _lastTime));
                weaponEnt.ReplaceMagazineAmmo(newAmmo);
               
                weaponEnt.AddShootingDelay(weaponEnt.timeShootDelay.Value);
                if (newAmmo == 0)
                    weaponEnt.AddReloading(weaponEnt.timeReload.Value);

                var unitEnt = GetUnitByWeaponId(weaponEnt.id.Value);
                if (unitEnt.isPlayer) continue;
               
                var _ray = new Ray();    
                _ray.origin = weaponEnt.transform.Value.position; 
                _ray.direction = (unitEnt.shootPoint.Value.position - _ray.origin).normalized;

                var dist = Vector3.Distance(_ray.origin, unitEnt.shootPoint.Value.position);
                Debug.DrawRay(_ray.origin, _ray.direction * dist, Color.green, weaponEnt.shootingDelay.Value);  

                int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, dist + 0.1f, ConfigsManager.BotConfig.ShootTargetLayerMask); 
                
                if (hitsCount == 0) continue;

                var targetCollider = _hitsBuffer[0].collider;
                if (!targetCollider.TryGetComponent<BodyPart>(out var bodyPart)) continue;
                var hitEntity = bodyPart.UnitEntity;

                if (hitEntity.isDead) continue;
                
                var resultdamage = 0f;
                var damage = 0f; 

                //_lastTime = Time.time;
                //Debug.Log(damage + " " + damageMultiplier + " " + damage * damageMultiplier);
                
                if (hitEntity.isPlayer) 
                {
                    damage = Random.Range(1f, 1.5f); 
                }
                else
                {
                    damage = weaponEnt.damageFalloffCurve.Value.Evaluate(dist);
                } 
               
                float damageMultiplier = GetDamageMultiplier(bodyPart.PartType);
                
                resultdamage = damage * damageMultiplier;
                var newHp = hitEntity.hp.Value - resultdamage; 
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