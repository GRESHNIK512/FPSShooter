//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ModelMaterialListenerComponent modelMaterialListener { get { return (ModelMaterialListenerComponent)GetComponent(GameComponentsLookup.ModelMaterialListener); } }
    public bool hasModelMaterialListener { get { return HasComponent(GameComponentsLookup.ModelMaterialListener); } }

    public void AddModelMaterialListener(System.Collections.Generic.List<IModelMaterialListener> newValue) {
        var index = GameComponentsLookup.ModelMaterialListener;
        var component = (ModelMaterialListenerComponent)CreateComponent(index, typeof(ModelMaterialListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceModelMaterialListener(System.Collections.Generic.List<IModelMaterialListener> newValue) {
        var index = GameComponentsLookup.ModelMaterialListener;
        var component = (ModelMaterialListenerComponent)CreateComponent(index, typeof(ModelMaterialListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveModelMaterialListener() {
        RemoveComponent(GameComponentsLookup.ModelMaterialListener);
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

    static Entitas.IMatcher<GameEntity> _matcherModelMaterialListener;

    public static Entitas.IMatcher<GameEntity> ModelMaterialListener {
        get {
            if (_matcherModelMaterialListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ModelMaterialListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherModelMaterialListener = matcher;
            }

            return _matcherModelMaterialListener;
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
public partial class GameEntity {

    public void AddModelMaterialListener(IModelMaterialListener value) {
        var listeners = hasModelMaterialListener
            ? modelMaterialListener.value
            : new System.Collections.Generic.List<IModelMaterialListener>();
        listeners.Add(value);
        ReplaceModelMaterialListener(listeners);
    }

    public void RemoveModelMaterialListener(IModelMaterialListener value, bool removeComponentWhenEmpty = true) {
        var listeners = modelMaterialListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveModelMaterialListener();
        } else {
            ReplaceModelMaterialListener(listeners);
        }
    }
}
