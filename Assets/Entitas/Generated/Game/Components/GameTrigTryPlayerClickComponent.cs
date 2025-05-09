//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Ui.TrigTryPlayerClickComponent trigTryPlayerClick { get { return (Ui.TrigTryPlayerClickComponent)GetComponent(GameComponentsLookup.TrigTryPlayerClick); } }
    public bool hasTrigTryPlayerClick { get { return HasComponent(GameComponentsLookup.TrigTryPlayerClick); } }

    public void AddTrigTryPlayerClick(bool newValue) {
        var index = GameComponentsLookup.TrigTryPlayerClick;
        var component = (Ui.TrigTryPlayerClickComponent)CreateComponent(index, typeof(Ui.TrigTryPlayerClickComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTrigTryPlayerClick(bool newValue) {
        var index = GameComponentsLookup.TrigTryPlayerClick;
        var component = (Ui.TrigTryPlayerClickComponent)CreateComponent(index, typeof(Ui.TrigTryPlayerClickComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTrigTryPlayerClick() {
        RemoveComponent(GameComponentsLookup.TrigTryPlayerClick);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : ITrigTryPlayerClickEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTrigTryPlayerClick;

    public static Entitas.IMatcher<GameEntity> TrigTryPlayerClick {
        get {
            if (_matcherTrigTryPlayerClick == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TrigTryPlayerClick);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTrigTryPlayerClick = matcher;
            }

            return _matcherTrigTryPlayerClick;
        }
    }
}
