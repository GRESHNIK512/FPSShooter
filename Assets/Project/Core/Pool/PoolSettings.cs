using System;
using UnityEngine;

[System.Serializable]
public class PoolSettings
{
    public MonoBehaviour ObjectPrefab;
    public int InitialCount;
}

public interface IPoolable
{
    event Action<IPoolable> ReturnPoolEvent;
    GameObject GameObject { get; }
    Transform Transform { get; }   
    void Show();    
}