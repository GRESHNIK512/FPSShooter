
public class Pistol : Weapon
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isFireWeapon = true;
     }
} 