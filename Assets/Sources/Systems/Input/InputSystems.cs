using Entitas;

public class InputSystems : Feature
{
    public InputSystems(Contexts contexts) : base("Input systems")
    {
        Add(new EmitInputSystem(contexts));
    }
}
