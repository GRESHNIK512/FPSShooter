using Entitas;
using Entitas.CodeGeneration.Attributes;
using SaveData;
using System; 

[Data, Unique]
public sealed class ClientDataComponent : IComponent { }

[Data]
public sealed class CurrentSceneIndexComponent : IComponent, ISaveData
{
    public int Value;
    public object GetValue => Value;
    public void SetValue(object value)
    {
        Value = Convert.ToInt32(value);
    }
}

[Data]
public sealed class LevelCompleteCountComponent : IComponent, ISaveData
{
    public int Value;
    public object GetValue => Value;
    public void SetValue(object value)
    {
        Value = Convert.ToInt32(value);
    }
}
