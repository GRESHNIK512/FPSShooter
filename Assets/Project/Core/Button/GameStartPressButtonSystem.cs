using Entitas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Button
{
    internal class GameStartPressButtonSystem : ReactiveSystem<UiEntity>
    {
        private Contexts _context;
        private GameEntity _levelManagerEnt;
        private DataEntity _clientDataEnt;


        private IGroup<UiEntity> _windowGroup;
        private IGroup<GameEntity> _startLoadLevelGroup;
        private List<int> _allLevelIndex = new();

        public GameStartPressButtonSystem(Contexts contexts) : base(contexts.ui)
        {
            _context = contexts;
            _windowGroup = _context.ui.GetGroup(UiMatcher.Window);
            _startLoadLevelGroup = _context.game.GetGroup(GameMatcher.StartLoadLevel);
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.TrigTryPlayerClick.Added());
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.isStartGameButton;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var buttonEnt in entities)
            {
                if (_levelManagerEnt == null)
                {
                    _levelManagerEnt = _context.game.levelManagerEntity;
                    _clientDataEnt = _context.data.clientDataEntity;
                }

                if (_startLoadLevelGroup.count == 0 && !_levelManagerEnt.isUnloadLevelInProcess)
                {
                    _levelManagerEnt.isStartLoadLevel = true;

                    var levelCompleteCount = _clientDataEnt.levelCompleteCount.Value;
                    var currentSceneIndex = _clientDataEnt.currentSceneIndex.Value;

                    if (levelCompleteCount >= ConfigsManager.LevelConfig.MaxlevelCount)
                    {
                        if (!_levelManagerEnt.isRepeatLevel)
                            SetNewIndexScene(in currentSceneIndex, out currentSceneIndex);
                    }
                    else
                        currentSceneIndex = levelCompleteCount;

                    _clientDataEnt.ReplaceCurrentSceneIndex(currentSceneIndex);
                    _levelManagerEnt.isRepeatLevel = false;

                    var asyncLoad = SceneManager.LoadSceneAsync(currentSceneIndex, LoadSceneMode.Additive);
                    asyncLoad.completed += LoadComplete;
                } 
            }
        }

        private void LoadComplete(AsyncOperation obj)
        {
            foreach (var windowEnt in _windowGroup.GetEntities())
            {
                windowEnt.isShowOnlyThisWindow = windowEnt.isGameLevelWindow;
            }

            _context.ui.CreateEntity().AddTrigRefreshStatusWindowDelay(0f);
        }

        private void SetNewIndexScene(in int currentSceneIndex, out int newSceneIndex)
        {
            if (_allLevelIndex.Count == 0)
            {
                for (int i = 0; i < ConfigsManager.LevelConfig.MaxlevelCount; i++)
                {
                    if (i == currentSceneIndex) continue;
                    _allLevelIndex.Add(i);
                }
            }

            newSceneIndex = _allLevelIndex[Random.Range(0, _allLevelIndex.Count)];
            _allLevelIndex.Remove(newSceneIndex);
        }
    }
}