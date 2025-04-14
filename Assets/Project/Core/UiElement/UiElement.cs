using Entitas.Unity;
using UnityEngine;

public abstract class UiElement : MonoBehaviour
{
    protected UiEntity _uiEntity;
    public UiEntity _UIEntity => _uiEntity;

    [SerializeField] private RectTransform _rectTransform;

    public virtual void Init()
    {
        _uiEntity = Contexts.sharedInstance.ui.CreateEntity();
        _uiEntity.AddRectTransform(_rectTransform);

#if UNITY_EDITOR
        gameObject.Link(_uiEntity);
#endif

    }
} 