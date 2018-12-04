using UnityEngine;
using Entitas;

public class GameMain : MonoBehaviour {

    private Contexts _contexts;
    private Systems _systems;
    // Use this for initialization
    void Start()
    {
        _contexts = Contexts.sharedInstance;
        _contexts.InitializeContextObservers();
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
        .Add(new DebugSystems(contexts));
    }
}
