using UnityEngine;

public abstract class Equipment : LevelObject
{
    [SerializeField] protected MeshRenderer _modelMeshRenderer;

    public override void Init()
    {
        base.Init();
        _gameEntity.isEquipment = true;
        _gameEntity.AddId(_gameEntity.creationIndex);
        _gameEntity.AddCount(1);
    }

    public virtual void AddDefaultSetting() { }
}