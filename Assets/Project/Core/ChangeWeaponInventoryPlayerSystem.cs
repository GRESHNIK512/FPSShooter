using Entitas;
using System.Collections.Generic; 

namespace Game
{
    internal class ChangeWeaponInventoryPlayerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _weaponSlotGroup;
        private IGroup<UiEntity> _weaponSelectSlotGroup;

        public ChangeWeaponInventoryPlayerSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _weaponSlotGroup = _context.ui.GetGroup(UiMatcher.WeaponSlotButton);
            _weaponSelectSlotGroup = _context.ui.GetGroup(UiMatcher.AllOf(UiMatcher.WeaponSlotButton, UiMatcher.Select));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.WeaponsId);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var inventoryEnt in entities)
            {
                int index = 0;

                foreach (var weaponId in inventoryEnt.weaponsId.Value)
                {
                    var weaponEnt = _context.game.GetEntityWithId(weaponId);

                    foreach (var weaponSlotEnt in _weaponSlotGroup.GetEntities())
                    {
                        if (weaponSlotEnt.index.Value != index) continue;

                        weaponSlotEnt.ReplaceWeaponType(weaponEnt.weaponType.Value); 
                        ++index;
                        break;
                    }
                }

                if (_weaponSelectSlotGroup.count != 0) continue;
               
                foreach (var weaponSlotEnt in _weaponSlotGroup.GetEntities())
                {
                    if (weaponSlotEnt.index.Value != 1) continue;
                   
                    weaponSlotEnt.isSelect = true;
                }
            }
        }
    }
}