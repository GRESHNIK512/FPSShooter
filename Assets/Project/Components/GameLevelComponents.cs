using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Ui]
public class DestroyOnEndLevelComponent : IComponent { }

[Game]
public class LevelComponent : IComponent { }

[Game]
public class ObjectLevelComponent : IComponent { }

[Game]
public class TransformComponent : IComponent 
{
    public Transform Value;
}

[Game]
public class RigidBodyComponent : IComponent
{
    public Rigidbody Value;
}

[Game, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
public class UnlinkComponent : IComponent { }

[Game]
public class SpawnerComponent : IComponent { }

[Game]
public class OwnerComponent : IComponent 
{
    public Owner Value;
}

[Game, Event(EventTarget.Self)]
public class SetPositionComponent : IComponent
{
    public Vector3 Value;
}

[Game, Event(EventTarget.Self)]
public class VelocityComponent : IComponent
{
    public Vector3 Value;
}

[Game, Event(EventTarget.Self)]
public class SetLocalPosition : IComponent
{
    public Vector3 Value;
}