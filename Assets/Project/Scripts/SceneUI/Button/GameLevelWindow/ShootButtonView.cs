using Buttons;

public class ShootButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isShootButton = true;
    }
}
