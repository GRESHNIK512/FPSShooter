using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace SaveData
{
    [Data, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class SaveDataComponent : IComponent { }

    [Data, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class LoadDataComponent : IComponent { }

    [Data, Event(EventTarget.Self)]
    public sealed class KeyDataComponent : IComponent
    {
        public string Value;
    }

    [Data, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class DataLoadCompleteComponent : IComponent { }

    [Data, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class DataLoadFailComponent : IComponent { }

    public interface ISaveData
    {
        object GetValue { get; }
        void SetValue(object value);
    } 
} 