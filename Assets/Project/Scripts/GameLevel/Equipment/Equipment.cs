using UnityEngine;

public abstract class Equipment : LevelObject, IModelMaterialListener
{
    [SerializeField] private MeshRenderer _modelMeshRenderer;

    public override void Init()
    {
        base.Init();
        _gameEntity.isEquipment = true;
        _gameEntity.AddId(_gameEntity.creationIndex);
        _gameEntity.AddCount(1);

        _gameEntity.AddModelMaterialListener(this);
    }

    public virtual void AddDefaultSetting() { }

    public void OnModelMaterial(GameEntity entity, Material value)
    {
       _modelMeshRenderer.material = value;
    }
}