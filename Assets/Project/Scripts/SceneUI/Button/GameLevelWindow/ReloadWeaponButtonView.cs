using Buttons;

public class ReloadWeaponButtonView : UiButton
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isReloadButton = true;
    }
}
