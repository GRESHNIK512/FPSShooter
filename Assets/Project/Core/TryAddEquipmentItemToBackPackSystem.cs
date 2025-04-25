using Entitas;
using System.Collections.Generic;
using UnityEngine; 

namespace Game
{
    internal class TryAddEquipmentItemToBackPackSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _inventoryPlayerGroup;

        public TryAddEquipmentItemToBackPackSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _inventoryPlayerGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Inventory));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
           return context.CreateCollector(GameMatcher.AllOf(
               GameMatcher.TryAddBackPack,
               GameMatcher.MassResult
           )); 
        }

        protected override bool Filter(GameEntity entity)
        { 
            return entity.isEquipment && entity.massByOneItem.Value > 0; 
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var equipmentEnt in entities)
            {  
                foreach (var inventoryEnt in _inventoryPlayerGroup.GetEntities())
                { 
                    var inventoryMass = inventoryEnt.massResult.Value;
                    var freeMassInBackPack = inventoryEnt.maxMass.Value - inventoryMass;
                    var stackEquipmentMass = equipmentEnt.massResult.Value;
                    var oneEquipmentMass = equipmentEnt.massByOneItem.Value;
                    var itemsDictionary = inventoryEnt.backpack.Items;
                    var startEquipmentCount = equipmentEnt.count.Value; 
                    bool isTotalAbsorption = true;

                    if (stackEquipmentMass > freeMassInBackPack && oneEquipmentMass <= freeMassInBackPack) // try add part
                    {
                        var canAddCountInBackPack = (int)(freeMassInBackPack / oneEquipmentMass);
                        stackEquipmentMass = canAddCountInBackPack * oneEquipmentMass;   
                        equipmentEnt.ReplaceCount(startEquipmentCount - canAddCountInBackPack);
                        startEquipmentCount = canAddCountInBackPack;
                        isTotalAbsorption = false;
                    }

                    if (!itemsDictionary.TryGetValue(equipmentEnt.equipmentKey.Value, out var list)) //have line with key?
                    {
                        list = new List<int>();
                        itemsDictionary.Add(equipmentEnt.equipmentKey.Value, list);
                    }

                    if (list.Count == 0) //first registration
                    {
                        list.Add(equipmentEnt.id.Value);
                       
                        if (!isTotalAbsorption)
                        {
                            CloneEquipmentWithCount(equipmentEnt, startEquipmentCount);
                        }

                        equipmentEnt.isInBackPack = true;
                    }
                    else //combine
                    {
                        var equipmentInDictionaryEnt = _context.game.GetEntityWithId(list[0]);
                        var newCount = equipmentInDictionaryEnt.count.Value + startEquipmentCount;
                        equipmentInDictionaryEnt.ReplaceCount(newCount);
                        if (isTotalAbsorption) 
                            equipmentEnt.isUnlink = true;
                    }  
                    inventoryEnt.ReplaceMassResult(inventoryMass + stackEquipmentMass);
                }
                equipmentEnt.isTryAddBackPack = false;
            }
        }

        private void CloneEquipmentWithCount(GameEntity equipmentEnt, int countLeft) 
        {
            
        }
    }
}