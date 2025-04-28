using System.Collections.Generic; 
using UnityEngine;

public class PoolService : MonoBehaviour
{
    private static PoolService _instance;
    public static PoolService Instance => _instance;

    [SerializeField] private PoolSettings[] PoolSettingsList; 
    private readonly Dictionary<System.Type, ObjectPool> _pools = new ();
    private readonly Dictionary<System.Enum, System.Type> _typeMap = new();  

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeTypeMappings();
        InitializePools();
    }

    private void InitializeTypeMappings()
    {
        // Снаряжение
        _typeMap.Add(EquipmentType.Pistol, typeof(PistolView));
        _typeMap.Add(EquipmentType.M16, typeof(M16View));
        _typeMap.Add(EquipmentType.Mm9, typeof(AmmoView));
        _typeMap.Add(EquipmentType.Mm556, typeof(AmmoView));
        _typeMap.Add(EquipmentType.MedKit, typeof(MedKitView));
        
        //_typeMap.Add(EquipmentType., typeof());
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

    public T GetObjectFromPool<T>(Transform parent, Vector3 pos) where T : MonoBehaviour =>
        _pools.TryGetValue(typeof(T), out var pool) 
        ? (T)pool.GetObject(parent, pos) 
        : null;

    public T GetObjectFromPool<T>(System.Enum enumType, Transform parent, Vector3 pos) where T : MonoBehaviour =>
    _typeMap.TryGetValue(enumType, out var type) && _pools.TryGetValue(type, out var pool)
        ? (T)pool.GetObject(parent, pos)
        : null;
}