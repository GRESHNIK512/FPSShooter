using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private MonoBehaviour _poolPrefab;

    private Queue<IPoolable> _objectQueue = new();
    private List<IPoolable> _activeObjects = new();

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
        var obj = (IPoolable)Instantiate(_poolPrefab, transform);
        obj.ReturnPoolEvent += ReturnObject;

        if (putInQueue)
        {
            obj.GameObject.SetActive(false);
            _objectQueue.Enqueue(obj);
        }

        return obj;
    }

    public IPoolable GetObject(Transform newParent)
    {
        var obj = _objectQueue.Count > 0 ? _objectQueue.Dequeue() : CreateObject(false);
        obj.Transform.SetParent(newParent);
        obj.Transform.localPosition = Vector3.zero;
        _activeObjects.Add(obj);
        return obj;
    }

    public void ReturnObject(IPoolable obj)
    {
        obj.GameObject.SetActive(false); //dirt 1 time 
        obj.Transform.SetParent(transform);
        _objectQueue.Enqueue(obj);
        _activeObjects.Remove(obj);
    }

    public void ReturnAllActiveObjects()
    {
        for (int i = _activeObjects.Count - 1; i >= 0; i--)
        {
            ReturnObject(_activeObjects[i]);
        }
    }
}