//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiContext {

    public UiEntity loseEndGameWindowEntity { get { return GetGroup(UiMatcher.LoseEndGameWindow).GetSingleEntity(); } }

    public bool isLoseEndGameWindow {
        get { return loseEndGameWindowEntity != null; }
        set {
            var entity = loseEndGameWindowEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isLoseEndGameWindow = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    static readonly Ui.LoseEndGameWindowComponent loseEndGameWindowComponent = new Ui.LoseEndGameWindowComponent();

    public bool isLoseEndGameWindow {
        get { return HasComponent(UiComponentsLookup.LoseEndGameWindow); }
        set {
            if (value != isLoseEndGameWindow) {
                var index = UiComponentsLookup.LoseEndGameWindow;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : loseEndGameWindowComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherLoseEndGameWindow;

    public static Entitas.IMatcher<UiEntity> LoseEndGameWindow {
        get {
            if (_matcherLoseEndGameWindow == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.LoseEndGameWindow);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherLoseEndGameWindow = matcher;
            }

            return _matcherLoseEndGameWindow;
        }
    }
}
