using Entitas;
using System.Collections.Generic;

namespace Game
{
    internal class DeadUnitSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _context;
        private GameEntity _levelManagerEnt;
        private DataEntity _clientDataEnt;

        private IGroup<GameEntity> _unitLiveBotGroup;
        private IGroup<UiEntity> _windowGroup;   

        public DeadUnitSystem(Contexts contexts) : base(contexts.game)
        {
            _context = contexts;
            _unitLiveBotGroup = _context.game.GetGroup(GameMatcher.AllOf(GameMatcher.Unit).NoneOf(GameMatcher.Dead, GameMatcher.Player));
            _windowGroup = _context.ui.GetGroup(UiMatcher.Window); 
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isUnit;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var unitEnt in entities)
            {
                if (_levelManagerEnt == null)
                {
                    _levelManagerEnt = _context.game.levelManagerEntity;
                    _clientDataEnt = _context.data.clientDataEntity;
                }
               
                if (unitEnt.isPlayer)
                {
                    ClearInteface();
                    foreach (var windowEnt in _windowGroup.GetEntities())
                    {
                        windowEnt.isShowOnlyThisWindow = windowEnt.isLoseEndGameWindow;
                    }

                    _levelManagerEnt.isRepeatLevel = true; 
                }
                else
                { 
                    if (_unitLiveBotGroup.count == 0)
                    { 
                        ClearInteface();
                        foreach (var windowEnt in _windowGroup.GetEntities())
                        {
                            windowEnt.isShowOnlyThisWindow = windowEnt.isWinEndGameWindow;
                        } 
                       
                        var nowLevelCompleteCount = _clientDataEnt.levelCompleteCount.Value;
                        _clientDataEnt.ReplaceLevelCompleteCount(++nowLevelCompleteCount); 
                        _clientDataEnt.isSaveData = true;    
                    }
                }  
                _context.ui.CreateEntity().AddTrigRefreshStatusWindowDelay(1f);
            }
        }  

        private void ClearInteface()
        {
            foreach (var windowEnt in _windowGroup.GetEntities())
            {
                if (windowEnt.isShowOnlyThisWindow)
                {
                    windowEnt.isShowOnlyThisWindow = false;
                    windowEnt.ReplaceCanvasEnable(false);
                    windowEnt.ReplaceGraphicRaycasterEnable(false);
                }
            } 
        }
    }
}