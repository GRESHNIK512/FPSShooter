using UnityEngine;
[CreateAssetMenu(fileName = "BotConfig", menuName = "ScriptableObjects/BotConfig", order = 1)]

public class BotConfig : ScriptableObject
{ 
    public float RotationSpeed = 5f;

    [Header("Shoot")] 
    public LayerMask ShootLayerMasks;
    public LayerMask ShootTargetLayerMask;
} 