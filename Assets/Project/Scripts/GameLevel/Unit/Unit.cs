using UnityEngine;

public abstract class Unit : LevelObject, IDeadListener
{
    [SerializeField] private BodyPart[] _bodyParts;
    [SerializeField] protected Transform _weaponTranform;  

    public override void Init()
    {
        base.Init();
        _gameEntity.isUnit = true; 
        _gameEntity.AddHp(100);
        _gameEntity.AddUnitWeaponTransform(_weaponTranform);  
        _gameEntity.AddDeadListener(this);

        foreach (var part in _bodyParts) 
        {
            part.SetEntity(_gameEntity);
        } 
    } 

    public virtual void OnDead(GameEntity entity)
    {
       
    }
} 