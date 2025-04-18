//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly UnlinkComponent unlinkComponent = new UnlinkComponent();

    public bool isUnlink {
        get { return HasComponent(GameComponentsLookup.Unlink); }
        set {
            if (value != isUnlink) {
                var index = GameComponentsLookup.Unlink;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : unlinkComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherUnlink;

    public static Entitas.IMatcher<GameEntity> Unlink {
        get {
            if (_matcherUnlink == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Unlink);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnlink = matcher;
            }

            return _matcherUnlink;
        }
    }
}
