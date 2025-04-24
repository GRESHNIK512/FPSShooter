using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class AddEquipmentToBackpackSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _levelGroup;

        public AddEquipmentToBackpackSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
            _levelGroup = _context.game.GetGroup(GameMatcher.Level);
        } 

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Backpack);
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
                    
                    ammoEnt.AddAmmoType(AmmoType.mm9);
                    ammoView.AddDefaultSetting();
                    ammoEnt.AddCount(75);
                    ammoEnt.isTryAddBackPack = true;

                    var ammoView1 = PoolService.Instance.GetObjectFromPool<AmmoView>(levelEnt.transform.Value);
                    ammoView1.Init();
                    var ammoEnt1 = ammoView1.GameEntity;
                    
                    ammoEnt1.AddAmmoType(AmmoType.mm556);
                    ammoView1.AddDefaultSetting();
                    ammoEnt1.AddCount(119);
                    ammoEnt1.isTryAddBackPack = true;
                }
            }
        } 
    }
}