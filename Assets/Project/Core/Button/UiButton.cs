using Entitas.Unity;

namespace Buttons
{
    public abstract class UiButton : Button
    {
        protected UiEntity _uiEntity;

        public override void Init()
        {
            _uiEntity = Contexts.sharedInstance.ui.CreateEntity();
            _uiEntity.isButton = true; 

            OnClickEvent += () => _uiEntity.ReplaceTrigTryPlayerClick(true); 

#if UNITY_EDITOR
            gameObject.Link(_uiEntity);
#endif
        } 
    }
}