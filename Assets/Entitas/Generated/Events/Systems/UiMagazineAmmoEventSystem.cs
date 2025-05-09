//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class UiMagazineAmmoEventSystem : Entitas.ReactiveSystem<UiEntity> {

    readonly System.Collections.Generic.List<IUiMagazineAmmoListener> _listenerBuffer;

    public UiMagazineAmmoEventSystem(Contexts contexts) : base(contexts.ui) {
        _listenerBuffer = new System.Collections.Generic.List<IUiMagazineAmmoListener>();
    }

    protected override Entitas.ICollector<UiEntity> GetTrigger(Entitas.IContext<UiEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(UiMatcher.MagazineAmmo)
        );
    }

    protected override bool Filter(UiEntity entity) {
        return entity.hasMagazineAmmo && entity.hasUiMagazineAmmoListener;
    }

    protected override void Execute(System.Collections.Generic.List<UiEntity> entities) {
        foreach (var e in entities) {
            var component = e.magazineAmmo;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.uiMagazineAmmoListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnMagazineAmmo(e, component.Value);
            }
        }
    }
}
