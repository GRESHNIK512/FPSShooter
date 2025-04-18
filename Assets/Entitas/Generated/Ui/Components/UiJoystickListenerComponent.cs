//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public JoystickListenerComponent joystickListener { get { return (JoystickListenerComponent)GetComponent(UiComponentsLookup.JoystickListener); } }
    public bool hasJoystickListener { get { return HasComponent(UiComponentsLookup.JoystickListener); } }

    public void AddJoystickListener(System.Collections.Generic.List<IJoystickListener> newValue) {
        var index = UiComponentsLookup.JoystickListener;
        var component = (JoystickListenerComponent)CreateComponent(index, typeof(JoystickListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceJoystickListener(System.Collections.Generic.List<IJoystickListener> newValue) {
        var index = UiComponentsLookup.JoystickListener;
        var component = (JoystickListenerComponent)CreateComponent(index, typeof(JoystickListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveJoystickListener() {
        RemoveComponent(UiComponentsLookup.JoystickListener);
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

    static Entitas.IMatcher<UiEntity> _matcherJoystickListener;

    public static Entitas.IMatcher<UiEntity> JoystickListener {
        get {
            if (_matcherJoystickListener == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.JoystickListener);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherJoystickListener = matcher;
            }

            return _matcherJoystickListener;
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
public partial class UiEntity {

    public void AddJoystickListener(IJoystickListener value) {
        var listeners = hasJoystickListener
            ? joystickListener.value
            : new System.Collections.Generic.List<IJoystickListener>();
        listeners.Add(value);
        ReplaceJoystickListener(listeners);
    }

    public void RemoveJoystickListener(IJoystickListener value, bool removeComponentWhenEmpty = true) {
        var listeners = joystickListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveJoystickListener();
        } else {
            ReplaceJoystickListener(listeners);
        }
    }
}
