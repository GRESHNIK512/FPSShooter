
public class M16 : Weapon
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isFireWeapon = true;
    }
}