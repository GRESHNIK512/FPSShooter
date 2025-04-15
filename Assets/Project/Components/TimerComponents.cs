using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class TimerComponent : IComponent { }

[Game, Event(EventTarget.Self)]
public class TimeComponent : IComponent
{
    public float Value;
}

[Game]
public class OriginalTimeDelayComponent: IComponent
{
    public float Value;
}

[Game, Cleanup(CleanupMode.DestroyEntity)]
public class TrigTimerEndComponent : IComponent { }

[Game]
public class TimerOnPauseComponent : IComponent { }

//Timers Type
[Game]
public class RefreshWindowStatusTimerComponent : IComponent { }