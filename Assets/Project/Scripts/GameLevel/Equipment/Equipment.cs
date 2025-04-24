using UnityEngine;

public abstract class Equipment : LevelObject
{
    [SerializeField] protected MeshRenderer _modelMeshRenderer;

    public override void Init()
    {
        base.Init();
        _gameEntity.isEquipment = true;
        _gameEntity.AddId(_gameEntity.creationIndex);
    }

    public abstract void AddDefaultSetting();
}