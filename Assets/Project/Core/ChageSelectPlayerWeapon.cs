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
            _playerWeaponGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.WeaponType, GameMatcher.Player));
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var weaponSlotEnt in entities) 
            {
                foreach (var weaponEnt in _playerWeaponGroup.GetEntities())
                {
                    weaponEnt.isSelect = weaponSlotEnt.weaponType.Value == weaponEnt.weaponType.Value;
                }
            }
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isWeaponSlotButton;
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.Select.Added());
        }
    }
}