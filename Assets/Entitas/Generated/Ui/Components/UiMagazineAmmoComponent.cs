//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiEntity {

    public MagazineAmmoComponent magazineAmmo { get { return (MagazineAmmoComponent)GetComponent(UiComponentsLookup.MagazineAmmo); } }
    public bool hasMagazineAmmo { get { return HasComponent(UiComponentsLookup.MagazineAmmo); } }

    public void AddMagazineAmmo(int newValue) {
        var index = UiComponentsLookup.MagazineAmmo;
        var component = (MagazineAmmoComponent)CreateComponent(index, typeof(MagazineAmmoComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMagazineAmmo(int newValue) {
        var index = UiComponentsLookup.MagazineAmmo;
        var component = (MagazineAmmoComponent)CreateComponent(index, typeof(MagazineAmmoComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMagazineAmmo() {
        RemoveComponent(UiComponentsLookup.MagazineAmmo);
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
public partial class UiEntity : IMagazineAmmoEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UiMatcher {

    static Entitas.IMatcher<UiEntity> _matcherMagazineAmmo;

    public static Entitas.IMatcher<UiEntity> MagazineAmmo {
        get {
            if (_matcherMagazineAmmo == null) {
                var matcher = (Entitas.Matcher<UiEntity>)Entitas.Matcher<UiEntity>.AllOf(UiComponentsLookup.MagazineAmmo);
                matcher.componentNames = UiComponentsLookup.componentNames;
                _matcherMagazineAmmo = matcher;
            }

            return _matcherMagazineAmmo;
        }
    }
}
