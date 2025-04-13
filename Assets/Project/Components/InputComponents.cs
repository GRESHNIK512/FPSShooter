using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input]
public class InputComponent : IComponent { }

[Input, Event(EventTarget.Self)]
public class TouchDeltaPositionComponent : IComponent
{
    public Vector3 Value;
} 