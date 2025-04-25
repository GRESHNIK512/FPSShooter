
public class MedKitView : Equipment
{ 
    public override void Init()
    {
        base.Init();
        _gameEntity.AddEquipmentKey($"{GetType()}");
        _gameEntity.AddMassByOneItem(50);
    }  
} 