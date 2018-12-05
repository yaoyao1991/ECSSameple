using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugWarnSystem : ReactiveSystem<DebugEntity>
{
    Contexts _contexts;
    public HandleDebugWarnSystem(Contexts contexts) : base(contexts.debug)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.meta.logService.instance.WarningMessage(e.debugWarning.message);
            e.Destroy();
        }
    }

    protected override bool Filter(DebugEntity entity)
    {
        return entity.hasDebugWarning;
    }

    protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
    {
        return context.CreateCollector(DebugMatcher.DebugWarning);
    }
}
