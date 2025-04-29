using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal class TryAddEquipmentItemToBackPackSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _inventoryPlayerGroup;
        private IGroup<GameEntity> _playerUnitGroup;

        public TryAddEquipmentItemToBackPackSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _inventoryPlayerGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Inventory, GameMatcher.Player));
            _playerUnitGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit, GameMatcher.Player));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf
                (GameMatcher.TryAddBackPack, GameMatcher.MassResult));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEquipment &&
                   entity.massByOneItem.Value > 0 &&
                  !entity.isWeapon;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var equipmentEnt in entities)
            {
                foreach (var inventoryEnt in _inventoryPlayerGroup.GetEntities())
                {
                    var oneItemMass = equipmentEnt.massByOneItem.Value;
                    var inventoryMass = inventoryEnt.massResult.Value;
                    var freeMassInBackPack = inventoryEnt.maxMass.Value - inventoryMass;
                    var stackMass = equipmentEnt.massResult.Value;
                    var equipmentCount = equipmentEnt.count.Value; 
                    var leftCount = 0;
                    bool isTotalAbsorption = true;

                    if (oneItemMass > freeMassInBackPack) break;
                    else if (stackMass > freeMassInBackPack) // try add part
                    {
                        var canAddCountInBackPack = (int)(freeMassInBackPack / oneItemMass);
                        stackMass = canAddCountInBackPack * oneItemMass;
                        leftCount = equipmentCount - canAddCountInBackPack; 
                        equipmentCount = canAddCountInBackPack;
                        isTotalAbsorption = false; 
                    }

                    var itemsDictionary = inventoryEnt.backpack.Items;
                    if (!itemsDictionary.TryGetValue(equipmentEnt.equipmentKey.Value, out var list)) //have line with key?
                    {
                        list = new List<int>();
                        itemsDictionary.Add(equipmentEnt.equipmentKey.Value, list);
                    }
                    
                    if (list.Count == 0) //first registration
                    {
                        list.Add(equipmentEnt.id.Value);

                        if (!isTotalAbsorption)
                            CloneEquipmentWithCount(equipmentEnt.equipmentType.Value, leftCount);

                        equipmentEnt.isInBackPack = true;
                        equipmentEnt.ReplaceCount(equipmentCount); //ent in dictionary  
                        equipmentEnt.ReplaceParent(GetPlayerTransform());
                        equipmentEnt.ReplaceVisibleObject(false);
                    }   
                    else //add to line
                    {
                        var equipmentInDictionaryEnt = _context.game.GetEntityWithId(list[0]);
                        var newCount = equipmentInDictionaryEnt.count.Value + equipmentCount;
                        equipmentInDictionaryEnt.ReplaceCount(newCount);
                      
                        if (!isTotalAbsorption)
                            equipmentEnt.ReplaceCount(leftCount);
                        else
                            equipmentEnt.isUnlink = true; //destroy 
                    }
                    inventoryEnt.ReplaceMassResult(inventoryMass + stackMass);
                }
                equipmentEnt.ReplaceSetPosition(GetPlayerTransform().position);
                equipmentEnt.isTryAddBackPack = false;
            }
        }

        private void CloneEquipmentWithCount(EquipmentType equipmentType, int count)
        {
            var equipmentView = PoolService.Instance.GetObjectFromPool<Equipment>(
                equipmentType, 
                _context.game.levelEntity.transform.Value,
                GetPlayerTransform().position);

            equipmentView.Init();
          
            var equipmentEnt = equipmentView.GameEntity;
            equipmentEnt.ReplaceEquipmentType(equipmentType);
            equipmentEnt.ReplaceCount(count);
        }

        private Transform GetPlayerTransform() 
        {  
            foreach (var playerEnt in _playerUnitGroup.GetEntities())
            {
                return playerEnt.transform.Value;
            }

            return null;
        }
    }
}