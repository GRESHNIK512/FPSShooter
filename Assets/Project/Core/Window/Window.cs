using Buttons;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour, ICanvasEnableListener, IGraphicRaycasterEnableListener
    //, IRectTransformListener
{
    protected UiEntity _uiEntity;
    //protected UiEntity _uiEntity => _uiEntity;

    [SerializeField] private Canvas _canvas;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;
    //[SerializeField] private RectTransform _rectTransform;

    [SerializeField] private UiButton[] _allButton;
    [SerializeField] private UiElement[] _allUiElement;

    public virtual void Init()
    {
        _uiEntity = Contexts.sharedInstance.ui.CreateEntity();

#if UNITY_EDITOR
        gameObject.Link(_uiEntity);
#endif

        _uiEntity.isWindow = true;

        //_uiEntity.AddRectTransform(_rectTransform); //remove

        _uiEntity.AddCanvasEnableListener(this);
        _uiEntity.AddGraphicRaycasterEnableListener(this);

        _uiEntity.AddCanvasEnable(false);
        _uiEntity.AddGraphicRaycasterEnable(false);

        for (int i = 0; i < _allButton.Length; i++)
        {
            _allButton[i].Init();
        }

        for (int i = 0; i < _allUiElement.Length; i++)
        {
            _allUiElement[i].Init();
        }
    }

    public void OnCanvasEnable(UiEntity entity, bool _value)
    {
        _canvas.enabled = _value;
    }

    public void OnGraphicRaycasterEnable(UiEntity entity, bool _value)
    {
        _graphicRaycaster.enabled = _value;
    }
}
