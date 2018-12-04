using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugSysSystem : ReactiveSystem<DebugEntity>
{
    ILogService _logService;
    public HandleDebugSysSystem(Contexts contexts, ILogService logService) : base(contexts.debug)
    {
        _logService = logService;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _logService.LogMessage(e.debugSys.message);
            e.Destroy();
        }
    }

    protected override bool Filter(DebugEntity entity)
    {
        return entity.hasDebugSys;
    }

    protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
    {
        return context.CreateCollector(DebugMatcher.DebugSys);
    }
}
