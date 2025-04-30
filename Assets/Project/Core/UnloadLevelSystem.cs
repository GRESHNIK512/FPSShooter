using Entitas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    internal class UnloadLevelSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private IGroup<GameEntity> _levelObjectGroup;
        private IGroup<GameEntity> _destroyOnEndLevelGroup;
        private IGroup<UiEntity> _starGameButtonGroup;
        private IGroup<UiEntity> _weaponSlotSelectGroup;

        public UnloadLevelSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _levelObjectGroup = _context.game.GetGroup(GameMatcher.ObjectLevel);
            _starGameButtonGroup = _context.ui.GetGroup(UiMatcher.StartGameButton);
            _destroyOnEndLevelGroup = _context.game.GetGroup(GameMatcher.DestroyOnEndLevel);
            _weaponSlotSelectGroup = _context.ui.GetGroup(UiMatcher.AllOf(UiMatcher.WeaponSlotButton, UiMatcher.Select));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LevelUnload);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isLevelManager;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var levelManagerEnt in entities)
            {
                levelManagerEnt.isUnloadLevelInProcess = true;
               
                UiClear();

                BaseClear();

                UnloadLevelAsync(levelManagerEnt); 
            }
        }

        private async void UnloadLevelAsync(GameEntity levelManagerEnt)
        {  
            await SceneManager.UnloadSceneAsync(_context.data.clientDataEntity.currentSceneIndex.Value);  

            levelManagerEnt.isUnloadLevelInProcess = false;

            if (levelManagerEnt.isNeedLoadNextLevelAfterUnload)
            {
                levelManagerEnt.isNeedLoadNextLevelAfterUnload = false;

                foreach (var startGameButtonEnt in _starGameButtonGroup.GetEntities())
                {
                    startGameButtonEnt.ReplaceTrigTryPlayerClick(true);
                }
            } 
        }

        private void UiClear() 
        {
            foreach (var weaponSlotEnt in _weaponSlotSelectGroup.GetEntities())
            {
                weaponSlotEnt.isSelect = false;
            }
        }

        private void BaseClear() 
        {
            foreach (var levelObjEnt in _levelObjectGroup.GetEntities())
            {
                levelObjEnt.isUnlink = true;
            }

            foreach (var destroyEnt in _destroyOnEndLevelGroup.GetEntities())
            {
                destroyEnt.Destroy();
            }
        }
    }
}