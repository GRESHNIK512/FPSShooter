//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameReloadingEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IGameReloadingListener> _listenerBuffer;

    public GameReloadingEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IGameReloadingListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.Reloading)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasReloading && entity.hasGameReloadingListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.reloading;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.gameReloadingListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnReloading(e, component.Value);
            }
        }
    }
}
