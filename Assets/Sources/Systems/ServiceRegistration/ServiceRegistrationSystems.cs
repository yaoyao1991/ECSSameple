using Entitas;

public class ServiceRegistrationSystems : Feature {
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        Add(new RegisterAppServiceSystem(contexts, services.app));
        Add(new RegisterInputServiceSystem(contexts, services.input));
        Add(new RegisterLogServiceSystem(contexts, services.log));
    }
}
