using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class EquipmentComponent : IComponent { }

[Game]
public class EquipmentKeyComponent : IComponent 
{
    public string Value;
}

[Game, Ui, Event(EventTarget.Self)]
public class EquipmentTypeComponent : IComponent
{
    public EquipmentType Value;
}

[Game, Event(EventTarget.Self)]
public class ModelMaterialComponent : IComponent
{
    public Material Value;
}

[Game]
public class MassResultComponent : IComponent 
{
    public float Value;
}

[Game]
public class MassByOneItemComponent : IComponent
{
    public float Value;
}

[Game, Ui, Event(EventTarget.Self)]
public class CountComponent : IComponent 
{
    public int Value;
}

[Game]
public class MaxCountInStackComponent : IComponent
{
    public int Value;
}

[Game]
public class InBackPackComponent : IComponent { }

[Game]
public class TryAddBackPackComponent : IComponent { }


//BackPack
[Game]
public class BackpackComponent : IComponent 
{
    public Dictionary<string, List<int>> Items;
}

[Game]
public class MaxMassComponent : IComponent
{
    public float Value;
}

