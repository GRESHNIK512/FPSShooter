using Entitas;
using Entitas.CodeGeneration.Attributes;
using SaveData;
using System;

[Game, Unique]
public sealed class LevelManagerComponent : IComponent { }

[Game]
public sealed class StartLoadLevelComponent : IComponent { }

[Game]
public sealed class LevelStartInitComponent : IComponent { }  

[Game]
public sealed class RepeatLevelComponent : IComponent { }

[Game]
public sealed class NeedLoadNextLevelAfterUnloadComponent : IComponent { }

[Game]
public sealed class UnloadLevelInProcess : IComponent { }

[Game, Cleanup(CleanupMode.RemoveComponent)]
public sealed class LevelUnloadComponent : IComponent { }