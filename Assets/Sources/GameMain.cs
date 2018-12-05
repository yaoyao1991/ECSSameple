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
        }
    }

    private Systems CreateSystems(Contexts contexts, Services services)
    {
        return new Feature("Systems")
        .Add(new ServiceRegistrationSystems(contexts, services))
        .Add(new AppSystems(contexts))
        .Add(new DebugSystems(contexts));
    }
}
