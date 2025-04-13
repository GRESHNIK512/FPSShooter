using Buttons;

public class StartGameButtonView : UiButton
{
    public override void Init() 
    {
        base.Init();
        _uiEntity.isStartGameButton = true;
    }
} 