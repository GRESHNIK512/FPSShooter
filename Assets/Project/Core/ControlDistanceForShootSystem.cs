using Entitas; 
using UnityEngine;

namespace Game
{
    internal class ControlDistanceForShootSystem : IExecuteSystem
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerLiveGroup;
        private IGroup<GameEntity> _botLiveGroup;
       
        private float _delay = 0.25f;
        //private float _addDelay = 0.9f;
        private float _timeDelay = 0;

        private RaycastHit[] _hitsBuffer = new RaycastHit[10];
        //private Vector3 _lastPlayerPosition;
        private Transform _targetShootPoint;

        public ControlDistanceForShootSystem(Contexts contexts)
        {
            _context = contexts;
            _playerLiveGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit,GameMatcher.Player).NoneOf(GameMatcher.Dead));
            _botLiveGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit).NoneOf(GameMatcher.Dead, GameMatcher.Player));
        }

        public void Execute()
        {
            foreach (var playerEnt in _playerLiveGroup.GetEntities())
            {
                _timeDelay -= Time.deltaTime;
                if (_timeDelay > 0) continue;

                //if (_lastPlayerPosition == playerEnt.transform.Value.position) _timeDelay += _delay + _addDelay;
                else _timeDelay += _delay; 
               
                foreach (var enemyEnt in _botLiveGroup.GetEntities())
                {
                    var inventoryEnt = _context.game.GetEntityWithId(enemyEnt.inventoryId.Value[0]);
                    var weaponEnt = _context.game.GetEntityWithId(inventoryEnt.weaponsId.Value[0]);

                    if (weaponEnt.hasReloading) continue;

                    _targetShootPoint = null;
                    Vector3 playerPos = playerEnt.transform.Value.position + Vector3.up;
                    Vector3 enemyPos = new Vector3(enemyEnt.transform.Value.position.x, enemyEnt.unitWeaponTransform.Value.position.y, enemyEnt.transform.Value.position.z);

                    float sqrDistance = (playerPos - enemyPos).sqrMagnitude;
                    var minDistance = 5f;

                    if (sqrDistance > minDistance * minDistance) continue;


                    foreach (var hitTransform in playerEnt.playerShootPoints.Value)
                    {
                        Ray _ray = new Ray(enemyPos, (hitTransform.position - enemyPos).normalized);
                        Debug.DrawRay(_ray.origin, _ray.direction * minDistance, Color.blue, 0.1f);

                        int hitsCount = Physics.RaycastNonAlloc(_ray, _hitsBuffer, minDistance, ConfigsManager.BotConfig.ShootLayerMasks);
                        if (hitsCount == 0) continue;

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

                        var _targetCollider = _hitsBuffer[targetIndexHit].collider;
                        if ((1 << _targetCollider.gameObject.layer & ConfigsManager.BotConfig.ShootTargetLayerMask.value) == 0) continue;

                        _targetShootPoint = hitTransform;
                        break;
                    } 

                    if (_targetShootPoint == null) continue;

                    if (!enemyEnt.hasAgroShootingTimer)
                        enemyEnt.AddAgroShootingTimer(ConfigsManager.BotConfig.AgroDelay);

                    enemyEnt.ReplaceShootPoint(_targetShootPoint);
                }
                //_lastPlayerPosition = playerEnt.transform.Value.position;
            }
        }
    }
}