using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem, ITearDownSystem
{
    Contexts _contexts;
    IInputService _inputService;
    InputEntity _inputEntity;
    public EmitInputSystem(Contexts contexts)
    {
        _contexts = contexts;
        _inputService = _contexts.meta.inputService.instance;
    }
    public void Initialize()
    {
        _contexts.input.isInputManager = true;
        _inputEntity = _contexts.input.inputManagerEntity;
    }

    public void Execute()
    {
        _inputEntity.ReplaceMouseDown(_inputService.mouseDown);
    }

    public void TearDown()
    {
        
    }
}
