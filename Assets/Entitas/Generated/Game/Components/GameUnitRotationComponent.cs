//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public UnitRotationComponent unitRotation { get { return (UnitRotationComponent)GetComponent(GameComponentsLookup.UnitRotation); } }
    public bool hasUnitRotation { get { return HasComponent(GameComponentsLookup.UnitRotation); } }

    public void AddUnitRotation(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.UnitRotation;
        var component = (UnitRotationComponent)CreateComponent(index, typeof(UnitRotationComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceUnitRotation(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.UnitRotation;
        var component = (UnitRotationComponent)CreateComponent(index, typeof(UnitRotationComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveUnitRotation() {
        RemoveComponent(GameComponentsLookup.UnitRotation);
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

    static Entitas.IMatcher<GameEntity> _matcherUnitRotation;

    public static Entitas.IMatcher<GameEntity> UnitRotation {
        get {
            if (_matcherUnitRotation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UnitRotation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnitRotation = matcher;
            }

            return _matcherUnitRotation;
        }
    }
}
