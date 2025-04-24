using Entitas;
using Entitas.CodeGeneration.Attributes;
 

[Game]
public class WeaponComponent : IComponent { } 


[Game, Cleanup(CleanupMode.RemoveComponent)]
public class ShootComponent : IComponent { }


[Game]
public class TryShootComponent : IComponent { }

[Game]
public sealed class IdComponent : IComponent //context.GetEntityWithId(id);
{
    [PrimaryEntityIndex]
    public int Value;
}

[Game, Ui, Event(EventTarget.Self, EventType.Added), Event(EventTarget.Self, EventType.Removed)]
public class SelectComponent : IComponent 
{

}

[Game, Ui, Event(EventTarget.Self)]
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

[Game, Ui, Event(EventTarget.Self)]
public class TimeReloadComponent : IComponent
{
    public float Value;
}

[Game, Ui, Event(EventTarget.Self)]
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

[Game, Ui, Event(EventTarget.Self)]
public class MagazineAmmoComponent : IComponent
{
    public int Value;
}

[Game, Event(EventTarget.Self)]
public class AmmoTypeComponent : IComponent
{
    public AmmoType Value;
}

[Game]
public class DamageFalloffCurveComponent : IComponent
{
    public UnityEngine.AnimationCurve Value;
}

[Game]
public class FireWeaponComponent : IComponent { }  