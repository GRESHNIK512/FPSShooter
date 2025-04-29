using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class ChageSelectPlayerWeapon : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _playerWeaponGroup;

        public ChageSelectPlayerWeapon(Contexts contexts) : base (contexts.ui)
        {
            _context = contexts;
            _playerWeaponGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.EquipmentType, GameMatcher.Player));
        } 

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.Select.Added());
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isWeaponSlotButton;
        } 

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var weaponSlotEnt in entities) 
            {
                foreach (var weaponEnt in _playerWeaponGroup.GetEntities())
                {
                    if (weaponSlotEnt.equipmentType.Value == weaponEnt.equipmentType.Value)
                    {
                        weaponEnt.isSelect = true;
                        if (weaponEnt.magazineAmmo.Value == 0) 
                            weaponEnt.ReplaceReloading(weaponEnt.timeReload.Value); 
                    }
                    else 
                    {
                        weaponEnt.isSelect = false;
                        if (weaponEnt.hasReloading) 
                            weaponEnt.reloading.Value = 0; // empty reload 
                    }
                    weaponEnt.ReplaceVisibleObject(weaponEnt.isSelect);
                }
            }
        } 
    }
}