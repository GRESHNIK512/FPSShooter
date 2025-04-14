using UnityEngine;

public abstract class Unit : LevelObject, ISetPositionListener, IDeadListener
{
    [SerializeField] private BodyPart[] _bodyParts;
    [SerializeField] protected Transform _weaponTranform;  

    public override void Init()
    {
        base.Init();
        _gameEntity.isUnit = true;
        _gameEntity.AddSetPositionListener(this);
        _gameEntity.AddHp(100);
        _gameEntity.AddUnitWeaponTransform(_weaponTranform);
        _gameEntity.AddDeadListener(this);

        foreach (var part in _bodyParts) 
        {
            part.SetEntity(_gameEntity);
        }
    }

    public void OnSetPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }

    public void OnDead(GameEntity entity)
    {
        EnableObject(false);
    }
} 