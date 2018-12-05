using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugErrorSystem : ReactiveSystem<DebugEntity>
{
    Contexts _contexts;
    public HandleDebugErrorSystem(Contexts contexts) : base(contexts.debug)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.meta.logService.instance.ErrorMessage(e.debugFatal.message);
            e.Destroy();
        }
    }

    protected override bool Filter(DebugEntity entity)
    {
        return entity.hasDebugFatal;
    }

    protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
    {
        return context.CreateCollector(DebugMatcher.DebugFatal);
    }
}
