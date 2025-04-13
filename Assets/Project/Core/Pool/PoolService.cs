using System.Collections.Generic;
using UnityEngine;

public class PoolService : MonoBehaviour
{
    private static PoolService _instance;
    public static PoolService Instance => _instance;

    [SerializeField] private PoolSettings[] PoolSettingsList; 
    private readonly Dictionary<System.Type, ObjectPool> _pools = new ();

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        InitializePools();
    }  

    private void InitializePools()
    {
        foreach (var settings in PoolSettingsList)
        {
            var poolGameObject = new GameObject(settings.ObjectPrefab.name);
            poolGameObject.transform.SetParent(transform);  

            var objectPool = poolGameObject.AddComponent<ObjectPool>();
            objectPool.Initialize(settings.ObjectPrefab, settings.InitialCount);
            _pools[settings.ObjectPrefab.GetType()] = objectPool;
        } 
    }

    public void ReturnAllObjectsInPools() 
    {
        foreach (var pool in _pools.Values)
        {
            pool.ReturnAllActiveObjects();
        }
    }

    public T GetObjectFromPool<T>(Transform parent) where T : MonoBehaviour =>
        _pools.TryGetValue(typeof(T), out var pool) ? (T)pool.GetObject(parent) : null;  
}