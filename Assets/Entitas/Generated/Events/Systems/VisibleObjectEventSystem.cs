//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class VisibleObjectEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IVisibleObjectListener> _listenerBuffer;

    public VisibleObjectEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IVisibleObjectListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.VisibleObject)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasVisibleObject && entity.hasVisibleObjectListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.visibleObject;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.visibleObjectListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnVisibleObject(e, component.Value);
            }
        }
    }
}
