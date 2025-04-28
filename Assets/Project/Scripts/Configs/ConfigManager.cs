using UnityEngine;

public static class ConfigsManager
{
    private static bool _initialized; 
    public static PlayerConfig PlayerConfig { get; private set; }
    public static BotConfig BotConfig { get; private set; } 
    public static LevelConfig LevelConfig { get; private set; } 
    public static EquipmentConfig EquipmentConfig { get; private set; }
    public static WeaponConfig WeaponConfig { get; private set; } 
    public static AmmoConfig AmmoConfig { get; private set; }

    public static void LoadConfigs()
    {
        //Dbg.Log("InitConfig");
        if (_initialized) return;

        PlayerConfig = Resources.Load<PlayerConfig>(nameof(PlayerConfig));
        BotConfig = Resources.Load<BotConfig>(nameof(BotConfig));
        LevelConfig = Resources.Load<LevelConfig>(nameof(LevelConfig));
        WeaponConfig = Resources.Load<WeaponConfig>(nameof(WeaponConfig));
        AmmoConfig = Resources.Load<AmmoConfig>(nameof(AmmoConfig));
        EquipmentConfig = Resources.Load<EquipmentConfig>(nameof(EquipmentConfig));

        _initialized = true;
    }
}
