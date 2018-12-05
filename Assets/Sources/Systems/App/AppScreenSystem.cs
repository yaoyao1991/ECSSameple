using System.Collections.Generic;
using Entitas;

public class AppScreenSystem : ReactiveSystem<AppEntity>
{
    Contexts _contexts;
    public AppScreenSystem(Contexts contexts) : base(contexts.app)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<AppEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.meta.appService.instance.SetResolution(e.screen.width, e.screen.height);
            e.Destroy();
        }
    }

    protected override bool Filter(AppEntity entity)
    {
        return entity.hasScreen;
    }

    protected override ICollector<AppEntity> GetTrigger(IContext<AppEntity> context)
    {
        return context.CreateCollector(AppMatcher.Screen);
    }
}
