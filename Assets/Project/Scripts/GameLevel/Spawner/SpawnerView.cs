using UnityEngine;

public class SpawnerView : LevelObject
{
    [SerializeField] private Owner _owner;

    public override void Init() 
    {
        base.Init();
        _gameEntity.isSpawner = true;
        _gameEntity.AddOwner(_owner);
        _gameEntity.ReplaceSetPosition(transform.position);
    }
}

public enum Owner 
{
    Player,
    Bot
}
