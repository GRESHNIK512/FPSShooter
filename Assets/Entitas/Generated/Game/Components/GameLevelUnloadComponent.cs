//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly LevelUnloadComponent levelUnloadComponent = new LevelUnloadComponent();

    public bool isLevelUnload {
        get { return HasComponent(GameComponentsLookup.LevelUnload); }
        set {
            if (value != isLevelUnload) {
                var index = GameComponentsLookup.LevelUnload;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : levelUnloadComponent;

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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLevelUnload;

    public static Entitas.IMatcher<GameEntity> LevelUnload {
        get {
            if (_matcherLevelUnload == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LevelUnload);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLevelUnload = matcher;
            }

            return _matcherLevelUnload;
        }
    }
}
