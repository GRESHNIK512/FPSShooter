using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class PlayerComponent : IComponent { }  

[Game]
public class UnitComponent : IComponent { }

[Game, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
public class JumpComponent : IComponent 
{
    public Vector3 Value;
}

[Game]
public class StayOnGroundComponent : IComponent 
{
    public bool Value;
}

[Game]
public class SitDownComponent : IComponent
{
    public bool Value;
}

[Game]
public class CameraComponent : IComponent
{
    public Camera Value;
}

[Game]
public class CameraOriginalPositionComponent : IComponent
{
    public Vector3 Value;
}

[Game, Event(EventTarget.Self)]
public class CameraPositionComponent : IComponent
{
    public Vector3 Value;
}

[Game]
public class CaplsuleOriginalHeightComponent : IComponent
{
    public float Value;
}

[Game, Event(EventTarget.Self)]
public class CaplsuleHeightComponent : IComponent
{
    public float Value;
}

[Game]
public class CapsuleColliderComponent : IComponent
{
    public CapsuleCollider Value;
}

[Game, Event(EventTarget.Self)]
public class UnitRotationComponent : IComponent
{
    public Vector3 Value;
}

[Game, Ui, Event(EventTarget.Self)]
public class HpComponent : IComponent
{
    public float Value;
}

[Game, Event(EventTarget.Self)]
public class DeadComponent : IComponent
{
    
}

[Game]
public class UnitWeaponTransformComponent : IComponent
{
    public Transform Value;
}

[Game]
public class PlayerShootPointsComponent : IComponent
{
    public Transform[] Value;
}

[Game]
public class ShootPointComponent : IComponent
{
    public Transform Value;
}

[Game]
public class AgroShootingTimerComponent : IComponent
{
    public float Value;
} 

[Game]
public class InventoryIdComponent : IComponent
{
    public List<int> Value;
} 