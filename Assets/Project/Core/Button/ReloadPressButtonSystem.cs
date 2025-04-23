using Entitas;
using System.Collections.Generic;

namespace Button
{
    internal class ReloadPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _selectWeaponPlayerGroup;

        public ReloadPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _selectWeaponPlayerGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Weapon, GameMatcher.Select, GameMatcher.Player));
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isReloadButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttonEnt in entities)
            {
                foreach (var weaponEnt in _selectWeaponPlayerGroup.GetEntities()) 
                {
                    if (weaponEnt.hasReloading || weaponEnt.magazineSize.Value == weaponEnt.magazineAmmo.Value) break;
                        weaponEnt.AddReloading(weaponEnt.timeReload.Value);
                }
            }
        }
    }
}