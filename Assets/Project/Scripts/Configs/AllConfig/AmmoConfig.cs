using UnityEngine;
[CreateAssetMenu(fileName = "AmmoConfig", menuName = "ScriptableObjects/AmmoConfig", order = 1)]

public class AmmoConfig : ScriptableObject
{
    public Material[] AmmoMaterials;
    public AmmoSetting[] AmmosSettings;
}

public enum AmmoType
{
    mm9,     // 9mm для пистолетов
    mm556   // 5.56mm для M16, AR-15 
}

[System.Serializable]
public class AmmoSetting 
{
    public AmmoType Type;
    public float Mass;
    public int MaxCountInStack; 
} 