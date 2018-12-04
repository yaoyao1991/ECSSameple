
public interface ILogService {
    void LogMessage(string message);
    void WarningMessage(string message);
    void ErrorMessage(string message);
    void Asset(bool b, string message);
}
