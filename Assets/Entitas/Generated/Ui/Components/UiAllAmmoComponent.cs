//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public AllAmmoComponent allAmmo { get { return (AllAmmoComponent)GetComponent(UiComponentsLookup.AllAmmo); } }
    public bool hasAllAmmo { get { return HasComponent(UiComponentsLookup.AllAmmo); } }

    public void AddAllAmmo(int newValue) {
        var index = UiComponentsLookup.AllAmmo;
        var component = (AllAmmoComponent)CreateComponent(index, typeof(AllAmmoComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAllAmmo(int newValue) {
        var index = UiComponentsLookup.AllAmmo;
        var component = (AllAmmoComponent)CreateComponent(index, typeof(AllAmmoComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAllAmmo() {
        RemoveComponent(UiComponentsLookup.AllAmmo);
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
public partial class UiEntity : IAllAmmoEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherAllAmmo;

    public static Entitas.IMatcher<UiEntity> AllAmmo {
        get {
            if (_matcherAllAmmo == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.AllAmmo);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherAllAmmo = matcher;
            }

            return _matcherAllAmmo;
        }
    }
}
