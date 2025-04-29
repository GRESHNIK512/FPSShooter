using Entitas;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    internal class ChangeAmmoWeaponSlotSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _weaponSlotGroup; 

        public ChangeAmmoWeaponSlotSystem(Contexts contexts) : base (contexts.game)
        {
            _context = contexts;
            _weaponSlotGroup = _context.ui.GetGroup(UiMatcher.WeaponSlotButton);
        } 

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Count);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isAmmo && entity.isInBackPack;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var ammoEnt in entities) 
            {
                foreach (var weaponSlotEnt in _weaponSlotGroup.GetEntities())
                {
                    if (ammoEnt.equipmentType.Value != weaponSlotEnt.ammoType.Value) continue;
                    Debug.Log(ammoEnt.count.Value);
                    weaponSlotEnt.ReplaceAllAmmo(ammoEnt.count.Value);
                }
            }
        } 
    }
}