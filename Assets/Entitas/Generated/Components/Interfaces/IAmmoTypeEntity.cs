//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IAmmoTypeEntity {

    AmmoTypeComponent ammoType { get; }
    bool hasAmmoType { get; }

    void AddAmmoType(EquipmentType newValue);
    void ReplaceAmmoType(EquipmentType newValue);
    void RemoveAmmoType();
}
