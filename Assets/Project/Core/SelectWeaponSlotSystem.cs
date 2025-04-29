using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class SelectWeaponSlotSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _weaponSlotGroup;

        public SelectWeaponSlotSystem(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts;
            _weaponSlotGroup = _context.ui.GetGroup(UiMatcher.WeaponSlotButton);
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.Select);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isWeaponSlotButton;
        } 

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var selectWeaponSlotEnt in entities) 
            { 
                foreach (var weaponSlotEnt in _weaponSlotGroup.GetEntities())
                {
                    if (selectWeaponSlotEnt != weaponSlotEnt)
                    {
                        if (weaponSlotEnt.isSelect) weaponSlotEnt.isSelect = false;
                        if (weaponSlotEnt.hasReloading) weaponSlotEnt.reloading.Value = 0;
                    }
                }
            }
        } 
    }
}