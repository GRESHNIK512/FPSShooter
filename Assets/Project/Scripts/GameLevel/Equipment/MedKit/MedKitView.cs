
public class MedKitView : Equipment
{ 
    public override void Init()
    {
        base.Init();
        _gameEntity.AddEquipmentType(EquipmentType.MedKit); 
    }  
} 