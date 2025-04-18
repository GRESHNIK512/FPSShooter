//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AgroShootingTimerComponent agroShootingTimer { get { return (AgroShootingTimerComponent)GetComponent(GameComponentsLookup.AgroShootingTimer); } }
    public bool hasAgroShootingTimer { get { return HasComponent(GameComponentsLookup.AgroShootingTimer); } }

    public void AddAgroShootingTimer(float newValue) {
        var index = GameComponentsLookup.AgroShootingTimer;
        var component = (AgroShootingTimerComponent)CreateComponent(index, typeof(AgroShootingTimerComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAgroShootingTimer(float newValue) {
        var index = GameComponentsLookup.AgroShootingTimer;
        var component = (AgroShootingTimerComponent)CreateComponent(index, typeof(AgroShootingTimerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAgroShootingTimer() {
        RemoveComponent(GameComponentsLookup.AgroShootingTimer);
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

    static Entitas.IMatcher<GameEntity> _matcherAgroShootingTimer;

    public static Entitas.IMatcher<GameEntity> AgroShootingTimer {
        get {
            if (_matcherAgroShootingTimer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AgroShootingTimer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAgroShootingTimer = matcher;
            }

            return _matcherAgroShootingTimer;
        }
    }
}
