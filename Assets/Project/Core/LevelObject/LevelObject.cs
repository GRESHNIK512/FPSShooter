using Entitas.Unity;
using System;
using UnityEngine;

public abstract class LevelObject : MonoBehaviour, IUnlinkListener, ISetLocalPositionListener, IObjectVisibleListener, ISetPositionListener,
    IPoolable
{
    protected GameEntity _gameEntity; 
    public GameEntity GameEntity => _gameEntity;

    public GameObject GameObject => gameObject; 
    public Transform Transform => transform; 
    public event Action<IPoolable> ReturnPoolEvent;  

    public virtual void Init()
    {  
        _gameEntity = Contexts.sharedInstance.game.CreateEntity();

        _gameEntity.isObjectLevel = true;

        _gameEntity.AddUnlinkListener(this);
        _gameEntity.AddSetLocalPositionListener(this);
        _gameEntity.AddObjectVisibleListener(this);
        _gameEntity.AddSetPositionListener(this);

        _gameEntity.AddTransform(transform); 
        _gameEntity.AddObjectVisible(true);

#if UNITY_EDITOR
        gameObject.Link(_gameEntity);
#endif 
    }

    public void OnUnlink(GameEntity entity)
    {
#if UNITY_EDITOR
        gameObject.Unlink();
#endif
        ReturnPoolEvent?.Invoke(this);
        _gameEntity.Destroy(); 
    } 

    public void EnableObject(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public void OnSetLocalPosition(GameEntity entity, Vector3 value)
    {
        transform.localPosition = value;
    }

    public void OnObjectVisible(GameEntity entity, bool value)
    {
        EnableObject(value);    
    }

    public void OnSetPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }
}