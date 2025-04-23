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
    public WeaponType WeaponType;
    //public FireMode SupportedFireModes;
    public FireMode DefaultFireMode; // ����� �� ���������
    //public int BurstCount; // ���������� ��������� � �������   
    public float TimeReaload;
    public float TimeShootDelay;
    public int MagazineSize;   
    public AmmoType AmmoType;
    public AnimationCurve DamageFalloffCurve;
    public float DistanceShoot;
    public float MinDamage;
    public float MaxDamage;
    public Sprite Sprite;
}

public enum WeaponType
{ 
    Pistol,
    M16,
}

[Flags]
public enum FireMode
{
    Single = 1,      // ���������
    //Burst = 2,       // ������� (��������, �� 3 ��������)
    Auto = 4,        // ��������������
    //BoltAction = 8   // ��� ����������� ��������
}

public enum AmmoType
{
    mm9,     // 9mm ��� ����������
    mm556   // 5.56mm ��� M16, AR-15 
}