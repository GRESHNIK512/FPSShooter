
public class AmmoView : Equipment, IAmmoTypeListener
{
    private AmmoType _ammoType;  

    public override void Init()
    {
        base.Init(); 
        _gameEntity.AddAmmoTypeListener(this);
    }

    public override void AddDefaultSetting()
    {
        var ammoSetting = GetAmmoSettingByType();
        _gameEntity.AddMassByOneItem(ammoSetting.Mass);
        _gameEntity.AddMaxCountInStack(ammoSetting.MaxCountInStack);
    }

    public void OnAmmoType(GameEntity entity, AmmoType value)
    {
        _ammoType = value;
        _modelMeshRenderer.material = ConfigsManager.AmmoConfig.AmmoMaterials[(int)value]; 
    }

    private AmmoSetting GetAmmoSettingByType() 
    {
        foreach (var ammoSetting in ConfigsManager.AmmoConfig.AmmosSettings)
        {
            if (ammoSetting.Type == _ammoType) return ammoSetting;
        }
        return null;
    }
} 