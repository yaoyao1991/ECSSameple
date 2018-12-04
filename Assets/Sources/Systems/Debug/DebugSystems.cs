using Entitas;

/*
how to add logs in the project.
var log = _contexts.debug.CreateEntity();
log.AddDebugLog("xxxx");
log.AddDebugWarning("xxxx");
log.AddDebugError("xxxx");
asset.AddDebugAsset(false|true, "xxxx");
 */
public class DebugSystems : Feature
{
    public DebugSystems(Contexts contexts) : base("Debug systems")
    {
        var service = new UnityDebugLogService();
        Add(new HandleDebugLogSystem(contexts, service));
        Add(new HandleDebugWarnSystem(contexts, service));
        Add(new HandleDebugErrorSystem(contexts, service));
        Add(new HandleDebugAssetSystem(contexts, service));
    }
}
