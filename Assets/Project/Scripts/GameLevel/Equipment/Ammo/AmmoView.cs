
public class AmmoView : Equipment 
{ 
    public override void Init()
    {
        base.Init();  
        _gameEntity.isAmmo = true;
    } 
} 