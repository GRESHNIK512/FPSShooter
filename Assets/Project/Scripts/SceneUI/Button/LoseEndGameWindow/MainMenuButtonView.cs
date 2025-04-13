using Buttons; 

public class MainMenuButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isMainMenuButton = true;
    }
}
