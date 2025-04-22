using Entitas;
using System.Collections.Generic; 

namespace Button
{
    internal class ShootPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _selectWeaponPlayer; 

        public ShootPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _selectWeaponPlayer = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Weapon, GameMatcher.Player, GameMatcher.Select));
            
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick.Added());
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isShootButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttoEnt in entities)
            {
                foreach (var weaponEnt in _selectWeaponPlayer.GetEntities()) 
                {
                    //Debug.Log("AddTryShoot");
                    weaponEnt.isTryShoot = true;
                } 
            }
        } 
    }
}