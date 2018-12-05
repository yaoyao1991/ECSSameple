﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugSysSystem : ReactiveSystem<DebugEntity>
{
    Contexts _contexts;
    public HandleDebugSysSystem(Contexts contexts) : base(contexts.debug)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.meta.logService.instance.LogMessage(e.debugSys.message);
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
