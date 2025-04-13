using UnityEngine;

public static class ConfigsManager
{
    private static bool _initialized;
    public static PlayerConfig PlayerConfig { get; private set; }
    public static BotConfig BotConfig { get; private set; }
    public static LevelConfig LevelConfig { get; private set; }
    public static WeaponConfig WeaponConfig { get; private set; }

    public static void LoadConfigs()
    {
        //Dbg.Log("InitCOnfig");
        if (_initialized) return;

        PlayerConfig = Resources.Load<PlayerConfig>(nameof(PlayerConfig));
        BotConfig = Resources.Load<BotConfig>(nameof(BotConfig));
        LevelConfig = Resources.Load<LevelConfig>(nameof(LevelConfig));
        WeaponConfig = Resources.Load<WeaponConfig>(nameof(WeaponConfig));

        _initialized = true;
    }
}
