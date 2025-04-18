//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SetLocalPosition setLocalPosition { get { return (SetLocalPosition)GetComponent(GameComponentsLookup.SetLocalPosition); } }
    public bool hasSetLocalPosition { get { return HasComponent(GameComponentsLookup.SetLocalPosition); } }

    public void AddSetLocalPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.SetLocalPosition;
        var component = (SetLocalPosition)CreateComponent(index, typeof(SetLocalPosition));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSetLocalPosition(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.SetLocalPosition;
        var component = (SetLocalPosition)CreateComponent(index, typeof(SetLocalPosition));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSetLocalPosition() {
        RemoveComponent(GameComponentsLookup.SetLocalPosition);
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

    static Entitas.IMatcher<GameEntity> _matcherSetLocalPosition;

    public static Entitas.IMatcher<GameEntity> SetLocalPosition {
        get {
            if (_matcherSetLocalPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SetLocalPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSetLocalPosition = matcher;
            }

            return _matcherSetLocalPosition;
        }
    }
}
