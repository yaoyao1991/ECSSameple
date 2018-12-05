using Entitas;

public class AppSystems : Feature
{
    public AppSystems(Contexts contexts) : base("App systems")
    {
        Add(new AppScreenSystem(contexts));
    }
}
