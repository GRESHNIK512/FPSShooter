//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IEquipmentTypeEntity {

    EquipmentTypeComponent equipmentType { get; }
    bool hasEquipmentType { get; }

    void AddEquipmentType(EquipmentType newValue);
    void ReplaceEquipmentType(EquipmentType newValue);
    void RemoveEquipmentType();
}
