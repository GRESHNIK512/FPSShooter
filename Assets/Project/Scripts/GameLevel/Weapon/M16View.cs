
public class M16View : Weapon
{
    public override void Init()
    {
        base.Init();
        _gameEntity.isFireWeapon = true;
        _gameEntity.AddEquipmentType(EquipmentType.M16);
    }
}