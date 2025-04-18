using Buttons;

public class CloseGameLevelButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isCloseGameLevelButton = true;
    }
} 