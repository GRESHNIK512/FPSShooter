using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game]
public class WeaponComponent : IComponent { }

[Game]
public sealed class IdComponent : IComponent //context.GetEntityWithId(id);
{
    [PrimaryEntityIndex]
    public int Value;
}

[Game]
public class SelectComponent : IComponent { }

[Game]
public class WeaponTypeComponent : IComponent
{
    public WeaponType Value;
}

[Game]
public class SupportedFireModesComponent : IComponent
{
    public FireMode Value;
}

[Game]
public class DefaultFireModeComponent : IComponent
{
    public FireMode Value;
}

[Game]
public class BurstCountComponent : IComponent
{
    public int Value;
}

[Game]
public class DistanceShootComponent : IComponent
{
    public float Value;
}

[Game]
public class TimeReloadComponent : IComponent
{
    public float Value;
}

[Game, Event(EventTarget.Self)]
public class ReloadingComponent : IComponent
{
    public float Value;
}

[Game]
public class TimeShootDelayComponent : IComponent
{
    public float Value;
}

[Game, Event(EventTarget.Self)]
public class ShootingDelayComponent : IComponent
{
    public float Value;
}

[Game]
public class MagazineSizeComponent : IComponent
{
    public int Value;
}

[Game]
public class AmmoTypeComponent : IComponent
{
    public AmmoType Value;
}

[Game]
public class DamageFalloffCurveComponent : IComponent
{
    public AnimationCurve Value;
} 