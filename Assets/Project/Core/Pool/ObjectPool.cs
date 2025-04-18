using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private MonoBehaviour _poolPrefab;
    private Queue<IPoolable> _objectQueue = new();  

    public void Initialize(MonoBehaviour poolPrefab, int initialCount)
    {
        _poolPrefab = poolPrefab;

        for (int i = 0; i < initialCount; i++)
        {
            CreateObject(true);
        }
    }

    private IPoolable CreateObject(bool putInQueue)
    {
        var _poolableObj = (IPoolable)Instantiate(_poolPrefab, transform);
        _poolableObj.ReturnPoolEvent += ReturnObject;

        if (putInQueue)
        {
            _poolableObj.GameObject.SetActive(false);
            _objectQueue.Enqueue(_poolableObj);
        }

        return _poolableObj;
    }

    public IPoolable GetObject(Transform newParent)
    {
        var _poolableObj = _objectQueue.Count > 0 ? _objectQueue.Dequeue() : CreateObject(false);
        _poolableObj.Transform.SetParent(newParent); 
        return _poolableObj;
    }

    public void ReturnObject(IPoolable obj)
    {
        obj.GameObject.SetActive(false); //dirt 1 time 
        obj.Transform.SetParent(transform);
        _objectQueue.Enqueue(obj); 
    }  
}