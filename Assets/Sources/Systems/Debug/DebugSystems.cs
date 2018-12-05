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
        Add(new HandleDebugLogSystem(contexts));
        Add(new HandleDebugWarnSystem(contexts));
        Add(new HandleDebugErrorSystem(contexts));
        Add(new HandleDebugAssetSystem(contexts));
    }
}
