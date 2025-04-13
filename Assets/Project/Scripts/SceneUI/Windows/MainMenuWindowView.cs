
public class MainMenuWindowView : Window
{
    public override void Init()
    {
        base.Init();    
        _uiEntity.isMainMenuWindow = true;
        _uiEntity.isShowOnlyThisWindow = true;
    }
} 