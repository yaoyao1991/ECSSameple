
public class Services {
    public readonly ILogService log;
    public readonly IInputService input;
    public readonly IAppService app;
    public Services(ILogService log, IInputService input, IAppService app)
    {
        this.log = log;
        this.input = input;
        this.app = app;
    }
}
