namespace console_hero;
using System.Text.Json;
using System.IO;
public class GameConfig
{
    public string PlayerName { get; set; } = "A man with no name";
    public string LogDirectory { get; set; } = "./logs";
    public string DungeonTheme { get; set; } = "Library"; 
}

public static class ConfigLoader
{
    public static GameConfig LoadConfig(string filePath = "config.json")
    {
        if (!File.Exists(filePath))
        {
            var defaultConfig = new GameConfig();
            string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            return defaultConfig;
        }

        string existingJson = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<GameConfig>(existingJson) ?? new GameConfig();
    }
}