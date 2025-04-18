using UnityEngine;
[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 1)]

public class PlayerConfig : ScriptableObject
{ 
    [Header("Move")]
    public float MoveSpeed;
    public float JumpHeight;  
    public LayerMask GroundLayerMask;  
    public float SitHeight;
    public float SitDownDelay;

    [Header("Camera")]
    public float Sensitivity;  
    public float RightPersentScreenArea; // Правая часть экрана (70%)

    [Header("Shoot")]
    public float MaxDistanceRay;
    public LayerMask ShootLayerMasks;
    public LayerMask ShootTargetLayerMask;
} 