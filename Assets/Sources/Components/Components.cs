using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using UnityEngine;

//Meta Components
[Meta, Unique]
public sealed class AppServiceComponent : IComponent
{
    public IAppService instance;
}

[Meta, Unique]
public sealed class LogServiceComponent : IComponent
{
    public ILogService instance;
}

[Meta, Unique]
public sealed class InputServiceComponent : IComponent
{
    public IInputService instance;
}

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

[App, Unique]
public sealed class ScreenComponent : IComponent
{
    public int width;
    public int height;
}

[Input, Unique]
public sealed class InputManagerComponent : IComponent
{

}

[Input, Unique]
public sealed class MouseDownComponent : IComponent
{
    public Dictionary<int, UnityEngine.Vector2?> mouseDown;
}



