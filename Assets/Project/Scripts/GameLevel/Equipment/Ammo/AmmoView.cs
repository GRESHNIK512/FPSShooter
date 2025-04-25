
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
        _gameEntity.AddEquipmentKey(_ammoType.ToString());
       
        foreach (var ammoSetting in ConfigsManager.AmmoConfig.AmmosSettings)
        {
            if (ammoSetting.Type != _ammoType) continue;
            _gameEntity.AddMassByOneItem(ammoSetting.Mass);
            _gameEntity.AddMaxCountInStack(ammoSetting.MaxCountInStack);
        }
       
        _gameEntity.ReplaceCount(_gameEntity.count.Value); 
    }

    public void OnAmmoType(GameEntity entity, AmmoType value)
    { 
        _ammoType = value; 
        _modelMeshRenderer.material = ConfigsManager.AmmoConfig.AmmoMaterials[(int)value];
        AddDefaultSetting();
    } 
} 