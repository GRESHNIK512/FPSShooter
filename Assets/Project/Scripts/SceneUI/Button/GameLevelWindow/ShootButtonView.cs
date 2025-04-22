using Buttons;
using UnityEngine.EventSystems;

public class ShootButtonView : UiButton, IPointerUpHandler
{
    public override void Init()
    {
        base.Init();
        _uiEntity.isShootButton = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _uiEntity.isTrigButtonUp = true;
    }
}
