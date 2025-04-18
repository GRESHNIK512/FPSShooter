//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly TimerOnPauseComponent timerOnPauseComponent = new TimerOnPauseComponent();

    public bool isTimerOnPause {
        get { return HasComponent(GameComponentsLookup.TimerOnPause); }
        set {
            if (value != isTimerOnPause) {
                var index = GameComponentsLookup.TimerOnPause;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : timerOnPauseComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherTimerOnPause;

    public static Entitas.IMatcher<GameEntity> TimerOnPause {
        get {
            if (_matcherTimerOnPause == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TimerOnPause);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTimerOnPause = matcher;
            }

            return _matcherTimerOnPause;
        }
    }
}
