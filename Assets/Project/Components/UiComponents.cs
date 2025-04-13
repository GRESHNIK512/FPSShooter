using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Ui
{
    [Ui]
    public class WindowComponent : IComponent { }

    [Ui]
    public class ShowOnlyThisWindowComponent : IComponent { }

    [Ui, Event(EventTarget.Self)]
    public class TrigRefreshStatusWindowDelayComponent : IComponent
    {
        public float Value;
    }

    [Ui, Event(EventTarget.Self)]
    public class RectTransformComponent : IComponent
    {
        public RectTransform Value;
    }

    [Ui, Event(EventTarget.Self)]
    public class CanvasEnableComponent : IComponent
    {
        public bool Value;
    }

    [Ui, Event(EventTarget.Self)]
    public class GraphicRaycasterEnableComponent : IComponent
    {
        public bool Value;
    }

    [Ui, Event(EventTarget.Self)]
    public class JoystickComponent : IComponent
    {
        public Joystick Value;
    }

    [Ui, Event(EventTarget.Self)]
    public class JoystickDirectionComponent : IComponent
    {
        public Vector2 Value;
    }

    //Window
    [Ui, Unique]
    public class MainMenuWindowComponent : IComponent { }

    [Ui, Unique]
    public class GameLevelWindowComponent : IComponent { }
    
    [Ui, Unique]
    public class WinEndGameWindowComponent : IComponent { }

    [Ui, Unique]
    public class LoseEndGameWindowComponent : IComponent { }
}