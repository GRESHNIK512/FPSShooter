//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public TouchDeltaPositionListenerComponent touchDeltaPositionListener { get { return (TouchDeltaPositionListenerComponent)GetComponent(InputComponentsLookup.TouchDeltaPositionListener); } }
    public bool hasTouchDeltaPositionListener { get { return HasComponent(InputComponentsLookup.TouchDeltaPositionListener); } }

    public void AddTouchDeltaPositionListener(System.Collections.Generic.List<ITouchDeltaPositionListener> newValue) {
        var index = InputComponentsLookup.TouchDeltaPositionListener;
        var component = (TouchDeltaPositionListenerComponent)CreateComponent(index, typeof(TouchDeltaPositionListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTouchDeltaPositionListener(System.Collections.Generic.List<ITouchDeltaPositionListener> newValue) {
        var index = InputComponentsLookup.TouchDeltaPositionListener;
        var component = (TouchDeltaPositionListenerComponent)CreateComponent(index, typeof(TouchDeltaPositionListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTouchDeltaPositionListener() {
        RemoveComponent(InputComponentsLookup.TouchDeltaPositionListener);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherTouchDeltaPositionListener;

    public static Entitas.IMatcher<InputEntity> TouchDeltaPositionListener {
        get {
            if (_matcherTouchDeltaPositionListener == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.TouchDeltaPositionListener);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTouchDeltaPositionListener = matcher;
            }

            return _matcherTouchDeltaPositionListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public void AddTouchDeltaPositionListener(ITouchDeltaPositionListener value) {
        var listeners = hasTouchDeltaPositionListener
            ? touchDeltaPositionListener.value
            : new System.Collections.Generic.List<ITouchDeltaPositionListener>();
        listeners.Add(value);
        ReplaceTouchDeltaPositionListener(listeners);
    }

    public void RemoveTouchDeltaPositionListener(ITouchDeltaPositionListener value, bool removeComponentWhenEmpty = true) {
        var listeners = touchDeltaPositionListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveTouchDeltaPositionListener();
        } else {
            ReplaceTouchDeltaPositionListener(listeners);
        }
    }
}
