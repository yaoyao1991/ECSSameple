using Entitas;

// Debug Components
[Debug]
public sealed class DebugLogComponent : IComponent
{
    public string message;
}

[Debug]
public sealed class DebugSysComponent : IComponent
{
    public string message;
}

[Debug]
public sealed class DebugWarningComponent : IComponent
{
    public string message;
}

[Debug]
public sealed class DebugFatalComponent : IComponent
{
    public string message;
}

[Debug]
public sealed class DebugAssetComponent : IComponent
{
    public bool b;
    public string message;
}

