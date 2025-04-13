using Buttons;

public class SitDownButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isSitDownButton = true;
    }
} 