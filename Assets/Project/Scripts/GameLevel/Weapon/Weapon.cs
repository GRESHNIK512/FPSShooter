
public abstract class Weapon : LevelObject
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isWeapon = true;
        _gameEntity.AddId(_gameEntity.creationIndex);
    }
} 