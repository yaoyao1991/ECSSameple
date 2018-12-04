using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugErrorSystem : ReactiveSystem<DebugEntity>
{
    ILogService _logService;
    public HandleDebugErrorSystem(Contexts contexts, ILogService logService) : base(contexts.debug)
    {
        _logService = logService;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _logService.ErrorMessage(e.debugFatal.message);
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
