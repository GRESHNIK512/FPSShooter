using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

[Game]
public class InventoryComponent : IComponent { }

[Game]
public class WeaponsIdComponent : IComponent 
{
    public List<int> Value;
} 