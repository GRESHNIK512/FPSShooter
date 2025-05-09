//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MaxCountInStackComponent maxCountInStack { get { return (MaxCountInStackComponent)GetComponent(GameComponentsLookup.MaxCountInStack); } }
    public bool hasMaxCountInStack { get { return HasComponent(GameComponentsLookup.MaxCountInStack); } }

    public void AddMaxCountInStack(int newValue) {
        var index = GameComponentsLookup.MaxCountInStack;
        var component = (MaxCountInStackComponent)CreateComponent(index, typeof(MaxCountInStackComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMaxCountInStack(int newValue) {
        var index = GameComponentsLookup.MaxCountInStack;
        var component = (MaxCountInStackComponent)CreateComponent(index, typeof(MaxCountInStackComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMaxCountInStack() {
        RemoveComponent(GameComponentsLookup.MaxCountInStack);
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

    static Entitas.IMatcher<GameEntity> _matcherMaxCountInStack;

    public static Entitas.IMatcher<GameEntity> MaxCountInStack {
        get {
            if (_matcherMaxCountInStack == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MaxCountInStack);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMaxCountInStack = matcher;
            }

            return _matcherMaxCountInStack;
        }
    }
}
