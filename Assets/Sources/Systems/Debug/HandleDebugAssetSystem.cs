using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class HandleDebugAssetSystem : ReactiveSystem<DebugEntity>
{
    Contexts _contexts;
    public HandleDebugAssetSystem(Contexts contexts) : base(contexts.debug)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<DebugEntity> entities)
    {
        foreach (var e in entities)
        {
            _contexts.meta.logService.instance.Asset(e.debugAsset.b, e.debugAsset.message);
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
