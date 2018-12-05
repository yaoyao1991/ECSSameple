using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem
{
    Contexts _contexts;
    IInputService _inputService;
    InputEntity _inputEntity;
    public EmitInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        _contexts.input.isInputManager = true;
        _inputEntity = _contexts.input.inputManagerEntity;
        _inputService = _contexts.meta.inputService.instance;
    }

    public void Execute()
    {
        _inputEntity.ReplaceMouseDown(_inputService.mouseDown);
    }

}
