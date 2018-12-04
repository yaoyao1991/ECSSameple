using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugAssetSystem : ReactiveSystem<DebugEntity>
{
    ILogService _logService;
    public HandleDebugAssetSystem(Contexts contexts, ILogService logService) : base(contexts.debug)
    {
        _logService = logService;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _logService.Asset(e.debugAsset.b, e.debugAsset.message);
            e.Destroy();
        }
    }

    protected override bool Filter(DebugEntity entity)
    {
        return entity.hasDebugAsset;
    }

    protected override ICollector<DebugEntity> GetTrigger(IContext<DebugEntity> context)
    {
        return context.CreateCollector(DebugMatcher.DebugAsset);
    }
}
