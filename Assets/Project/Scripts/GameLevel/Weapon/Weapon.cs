
public abstract class Weapon : LevelObject, IGameSelectListener, IGameSelectRemovedListener
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isWeapon = true;
        _gameEntity.AddId(_gameEntity.creationIndex);
        _gameEntity.AddGameSelectListener(this);
        _gameEntity.AddGameSelectRemovedListener(this);
    }

    public void OnSelect(GameEntity entity)
    {
        EnableObject(true);
    }

    public void OnSelectRemoved(GameEntity entity)
    {
        EnableObject(false);
    }
} 