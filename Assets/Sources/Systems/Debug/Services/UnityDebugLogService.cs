using UnityEngine;

public class UnityDebugLogService : ILogService
{
    public void LogMessage(string message)
    {
        Debug.Log(message);
    }

    public void WarningMessage(string message)
    {
        Debug.LogWarning(message);
    }

    public void ErrorMessage(string message)
    {
        Debug.LogError(message);
    }

    public void Asset(bool b, string message)
    {
        Debug.Assert(b, message);
    }
}
