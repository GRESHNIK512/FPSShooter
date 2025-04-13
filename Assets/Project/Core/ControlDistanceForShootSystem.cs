using DG.Tweening;
using Entitas;
using UnityEngine;

namespace Game
{
    internal class ControlDistanceForShootSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerGroup;
        private IGroup<GameEntity> _enemyGroup;
        private float _delay = 0.1f;
        private float _timerDelay = 0;

        private Ray _ray = new Ray();
        private RaycastHit[] _hitsBuffer = new RaycastHit[10];
        private Collider _targetCollider;
        private Transform _targetShootPoint;

        public ControlDistanceForShootSystem(Contexts contexts)
        {
            _context = contexts;
            _playerGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player).NoneOf(GameMatcher.Dead));
            _enemyGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit).NoneOf(GameMatcher.Dead, GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var playerEnt in _playerGroup.GetEntities())
            {
                _timerDelay -= Time.deltaTime;
                if (_timerDelay <= 0)
                {
                    _timerDelay += _delay;
                    foreach (var enemyEnt in _enemyGroup.GetEntities())
                    {
                        _targetShootPoint = null;
                        Vector3 playerPos = playerEnt.transform.Value.position + Vector3.up;
                        Vector3 enemyPos = enemyEnt.transform.Value.position + Vector3.up; 

                        float sqrDistance = (playerPos - enemyPos).sqrMagnitude; 
                        var minDistance = 5f; 
                        
                        if (sqrDistance <= minDistance * minDistance)
                        {  
                            foreach (var hitTransform in playerEnt.playerShootPoints.Value)
                            {
                                _ray.origin = enemyPos;
                                _ray.direction = (hitTransform.position - _ray.origin).normalized;
                                Debug.DrawRay(_ray.origin, _ray.direction * minDistance, Color.blue, 0.05f);
                                int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, minDistance, ConfigsManager.BotConfig.ShootLayerMasks);
                                if (hitsCount > 0) 
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
                                    if ((1 << _targetCollider.gameObject.layer & ConfigsManager.BotConfig.ShootTargetLayerMask.value) != 0)
                                    {
                                        _targetShootPoint = hitTransform;
                                        break;
                                    }
                                }
                            }
                        }
                        enemyEnt.ReplaceShootPoint(_targetShootPoint);
                    }
                }
            }
        }
    }
}