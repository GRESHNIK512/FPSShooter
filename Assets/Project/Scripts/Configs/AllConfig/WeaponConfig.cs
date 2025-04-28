using System;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "ScriptableObjects/WeaponConfig", order = 1)]

public class WeaponConfig : ScriptableObject
{
    public Color BackgroundColor;
    public Color SelectColor; 
    public WeaponSettings[] Weapons;
}  

[System.Serializable]
public class WeaponSettings 
{
    public Weapon Prefab;
    public EquipmentType Type;
    //public FireMode SupportedFireModes;
    public FireMode DefaultFireMode; // Режим по умолчанию
    //public int BurstCount; // Количество выстрелов в очереди   
    public float TimeReaload;
    public float TimeShootDelay;
    public int MagazineSize;   
    public EquipmentType AmmoType;
    public AnimationCurve DamageFalloffCurve;
    public float DistanceShoot;
    public float MinDamage;
    public float MaxDamage; 
}  

[Flags]
public enum FireMode
{
    Single = 1,      // Одиночный
    //Burst = 2,       // Очередь (например, по 3 выстрела)
    Auto = 4,        // Автоматический
    //BoltAction = 8   // Для снайперских винтовок
} 