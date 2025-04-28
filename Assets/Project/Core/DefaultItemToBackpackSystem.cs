using Entitas;
using System.Collections.Generic;
using UnityEngine;  

namespace Game
{
    internal class DefaultItemToBackpackSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _levelGroup;

        public DefaultItemToBackpackSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
            _levelGroup = _context.game.GetGroup(GameMatcher.Level);
        } 

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Backpack.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        { 
            foreach (var inventoryEnt in entities) 
            {
                foreach (var levelEnt in _levelGroup.GetEntities())
                {
                    var ammoView = PoolService.Instance.GetObjectFromPool<AmmoView>(levelEnt.transform.Value);
                    ammoView.Init();
                    var ammoEnt = ammoView.GameEntity;
                   
                    ammoEnt.ReplaceEquipmentType(EquipmentType.Mm9);
                    ammoEnt.ReplaceCount(300);  
                    ammoEnt.isTryAddBackPack = true;

                    //var ammoView1 = PoolService.Instance.GetObjectFromPool<AmmoView>(levelEnt.transform.Value);
                    //ammoView1.Init();
                    //var ammoEnt1 = ammoView1.GameEntity;

                    //ammoEnt1.AddEquipmentType(EquipmentType.Mm556);
                    //ammoEnt1.count.Value = 30;
                    //ammoEnt1.isTryAddBackPack = true;
                }
            }
        } 
    }
}