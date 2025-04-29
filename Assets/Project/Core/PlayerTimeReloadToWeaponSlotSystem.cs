using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class PlayerTimeReloadToWeaponSlotSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<UiEntity> _weaponSlotGroup;

        public PlayerTimeReloadToWeaponSlotSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _weaponSlotGroup = _context.ui.GetGroup(UiMatcher.WeaponSlotButton);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TimeReload);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isWeapon &&
                   entity.isPlayer;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var weaponEnt in entities)
            {
                foreach (var weaponSlotEnt in _weaponSlotGroup.GetEntities())
                {
                    if (weaponEnt.equipmentType.Value == weaponSlotEnt.equipmentType.Value)
                    {
                        weaponSlotEnt.ReplaceTimeReload(weaponEnt.timeReload.Value);
                        break;
                    }
                }
            }
        }
    }
}