using Buttons;

public class JumpPlayerButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isJumpPlayerButton = true;
    }
}
