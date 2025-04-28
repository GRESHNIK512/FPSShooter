using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentConfig", menuName = "ScriptableObjects/EquipmentConfig", order = 1)]

public class EquipmentConfig : ScriptableObject
{
    public EquipmentSettings[] EquipmentSettings;
}

public enum EquipmentType 
{
    Pistol,
    M16,
    Mm9,     
    Mm556,
    MedKit
}

[System.Serializable]
public class EquipmentSettings
{
    public EquipmentType Type;
    public float Mass;
    public int MaxCountInStack;
    public Sprite Sprite;
    public Material Material;
}