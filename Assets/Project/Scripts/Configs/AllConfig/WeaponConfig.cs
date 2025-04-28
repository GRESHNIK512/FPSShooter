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
    public FireMode DefaultFireMode; // ����� �� ���������
    //public int BurstCount; // ���������� ��������� � �������   
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
    Single = 1,      // ���������
    //Burst = 2,       // ������� (��������, �� 3 ��������)
    Auto = 4,        // ��������������
    //BoltAction = 8   // ��� ����������� ��������
} 