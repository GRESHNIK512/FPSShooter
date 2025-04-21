using Entitas;
using System.Collections.Generic;

namespace Button
{
    internal class WeaponSlotPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context; 

        public WeaponSlotPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts; 
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isWeaponSlotButton;
        } 

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var weaponSlotEnt in entities) 
            {
                if (!weaponSlotEnt.isSelect)
                {
                    weaponSlotEnt.isSelect = true; 
                }
            }
        } 
    }
}