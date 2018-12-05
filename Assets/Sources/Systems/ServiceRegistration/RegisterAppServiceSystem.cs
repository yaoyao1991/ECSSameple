using Entitas;

public class RegisterAppServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IAppService _appService;
    public RegisterAppServiceSystem(Contexts contexts, IAppService appService)
    {
        _metaContext = contexts.meta;
        _appService = appService;
    }

    public void Initialize()
    {
        _metaContext.ReplaceAppService(_appService);
    }
}
