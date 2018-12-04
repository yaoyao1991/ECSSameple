﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugWarnSystem : ReactiveSystem<DebugEntity>
{
    ILogService _logService;
    public HandleDebugWarnSystem(Contexts contexts, ILogService logService) : base(contexts.debug)
    {
        _logService = logService;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _logService.WarningMessage(e.debugWarning.message);
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
