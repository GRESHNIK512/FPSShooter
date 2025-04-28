
public class PistolView : Weapon
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isFireWeapon = true;
        _gameEntity.AddEquipmentType(EquipmentType.Pistol);
     }
} 