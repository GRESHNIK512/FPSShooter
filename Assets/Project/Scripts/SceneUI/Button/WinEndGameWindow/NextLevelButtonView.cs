using Buttons;

public class NextLevelButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isNextLevelButton = true;
    }
}