//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DataContext {

    public DataEntity clientDataEntity { get { return GetGroup(DataMatcher.ClientData).GetSingleEntity(); } }

    public bool isClientData {
        get { return clientDataEntity != null; }
        set {
            var entity = clientDataEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isClientData = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class DataEntity {

    static readonly ClientDataComponent clientDataComponent = new ClientDataComponent();

    public bool isClientData {
        get { return HasComponent(DataComponentsLookup.ClientData); }
        set {
            if (value != isClientData) {
                var index = DataComponentsLookup.ClientData;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : clientDataComponent;

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
public sealed partial class DataMatcher {

    static Entitas.IMatcher<DataEntity> _matcherClientData;

    public static Entitas.IMatcher<DataEntity> ClientData {
        get {
            if (_matcherClientData == null) {
                var matcher = (Entitas.Matcher<DataEntity>)Entitas.Matcher<DataEntity>.AllOf(DataComponentsLookup.ClientData);
                matcher.componentNames = DataComponentsLookup.componentNames;
                _matcherClientData = matcher;
            }

            return _matcherClientData;
        }
    }
}
