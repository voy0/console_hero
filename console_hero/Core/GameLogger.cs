using System;
using System.Collections.Generic;
using System.IO;

public interface ILoggerStrategy
{
    void Log(string message);
    List<string> GetAllLogs();
    string GetCurrentLogFilePath(); 
}

public class MemoryLogger : ILoggerStrategy
{
    private readonly List<string> _logs = new();
    public void Log(string message) => _logs.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
    public List<string> GetAllLogs() => _logs;
    public string GetCurrentLogFilePath() => "No file";
}

public class FileLogger : ILoggerStrategy
{
    private readonly string _filePath;
    private readonly List<string> _logs = new();

    public FileLogger(string playerName, string logDirectory)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        if (!Directory.Exists(logDirectory)) Directory.CreateDirectory(logDirectory); 
        
        _filePath = Path.Combine(logDirectory, $"{playerName}_{timestamp}_log.txt");
    }

    public void Log(string message)
    {
        string formattedMessage = $"[{DateTime.Now:HH:mm:ss}] {message}";
        _logs.Add(formattedMessage);
        File.AppendAllText(_filePath, formattedMessage + Environment.NewLine);
    }

    public List<string> GetAllLogs() => _logs;
    public string GetCurrentLogFilePath() => _filePath; 
}

public class CompositeLogger : ILoggerStrategy
{
    private readonly List<ILoggerStrategy> _loggers;
    public CompositeLogger(params ILoggerStrategy[] loggers) => _loggers = new List<ILoggerStrategy>(loggers);

    public void Log(string message) => _loggers.ForEach(l => l.Log(message));
    public List<string> GetAllLogs() => _loggers.Count > 0 ? _loggers[0].GetAllLogs() : new List<string>();
    
    public string GetCurrentLogFilePath() 
    {
        foreach(var logger in _loggers)
            if (logger is FileLogger fl) return fl.GetCurrentLogFilePath();
        return "File does not exist";
        
    }
    
}

public class GameLogger
{
    private static GameLogger? _instance;

    private GameLogger(){ }
    public static GameLogger Instance => _instance ??= new GameLogger();
    
    private ILoggerStrategy _strategy = new MemoryLogger(); 

    public void SetStrategy(ILoggerStrategy strategy) => _strategy = strategy;
    public void Log(string message) => _strategy.Log(message);
    public List<string> GetLogs() => _strategy.GetAllLogs();
    
    public List<string> GetRecentLogs(int count) 
    {
        var logs = _strategy.GetAllLogs();
        int skip = Math.Max(0, logs.Count - count);
        return logs.GetRange(skip, logs.Count - skip);
    }
    public string GetFilePath() => _strategy.GetCurrentLogFilePath();
}