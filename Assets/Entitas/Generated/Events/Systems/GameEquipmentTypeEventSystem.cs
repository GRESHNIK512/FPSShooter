//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEquipmentTypeEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IGameEquipmentTypeListener> _listenerBuffer;

    public GameEquipmentTypeEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IGameEquipmentTypeListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.EquipmentType)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasEquipmentType && entity.hasGameEquipmentTypeListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.equipmentType;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.gameEquipmentTypeListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnEquipmentType(e, component.Value);
            }
        }
    }
}
