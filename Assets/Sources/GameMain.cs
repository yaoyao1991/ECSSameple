using UnityEngine;
using Entitas;

public class GameMain : MonoBehaviour {

    private Contexts _contexts;
    private Systems _systems;
    // Use this for initialization
    void Start()
    {
        var _services = new Services(
            new UnityDebugLogService(),
            new UnityInputService(),
            new UnityAppService()
            );
        _contexts = Contexts.sharedInstance;
        _contexts.InitializeContextObservers();
        _systems = CreateSystems(_contexts, _services);
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
        if (Input.GetMouseButtonDown(0))
        {
            var e = _contexts.app.CreateEntity();
            e.AddScreen(100, 100);
            var log = _contexts.debug.CreateEntity();
            log.AddDebugSys("11111111111");
            var input = _contexts.input.inputManagerEntity;
            foreach (var down in input.mouseDown.mouseDown)
            {
                if (down.Value.HasValue)
                {
                    var log2 = _contexts.debug.CreateEntity();
                    log2.AddDebugLog(down.Key + " " + down.Value.Value.x + " " + down.Value.Value.y);
                }
            }
        }
    }

    private Systems CreateSystems(Contexts contexts, Services services)
    {
        return new Feature("Systems")
        .Add(new ServiceRegistrationSystems(contexts, services))
        .Add(new AppSystems(contexts))
        .Add(new InputSystems(contexts))
        .Add(new DebugSystems(contexts));
    }
}
