using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Button
{
    internal class ShootPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerUnitGroup;
       
        private RaycastHit[] _hitsBuffer = new RaycastHit[10];
        private Ray _ray = new Ray();
        private Transform _camTranform;
        private Collider _targetCollider;
        GameEntity _hitEntity;

        public ShootPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.Player); 
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
                SetPositionAndDirForRaycast();

                // Проверяем попадание в объект на нужном слое
                int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, ConfigsManager.PlayerConfig.MaxDistanceRay, ConfigsManager.PlayerConfig.ShootLayerMasks);

                if (hitsCount == 0)
                    continue;  //Debug.Log("Did not hit");  
                else
                {
                    float minDist = float.MaxValue;
                    int targetIndexHit = -1;
                   
                    for (int i = 0; i < hitsCount; i++)
                    {
                        var distance = (_ray.origin - _hitsBuffer[i].point).sqrMagnitude;
                        if (distance <= minDist)
                        {
                            minDist = distance;
                            targetIndexHit = i;
                        }
                    }
                    
                    _targetCollider = _hitsBuffer[targetIndexHit].collider;

                    if ((1 << _targetCollider.gameObject.layer & ConfigsManager.PlayerConfig.ShootTargetLayerMask.value) != 0)
                    {
                        if (_targetCollider.TryGetComponent<BodyPart>(out var bodyPart))
                        { 
                            var damage = 50;
                            float damageMultiplier = GetDamageMultiplier(bodyPart.PartType);

                            // Применяем урон с учетом множителя
                            _hitEntity = bodyPart.UnitEntity;
                          
                            if (!_hitEntity.isDead)
                            {
                                var newHp = _hitEntity.hp.Value - damage * damageMultiplier;
                                
                                if (newHp <= 0)
                                    newHp = 0;
                                
                                _hitEntity.ReplaceHp(newHp);
                            }
                        }
                    }
                }
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