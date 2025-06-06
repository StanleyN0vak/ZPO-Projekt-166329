using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zarzadzanie_Ksiazkami;

public class AppConfig
{
	private static AppConfig _instance;
	private static readonly object _lock = new object();

    public string FilePath { get; set; } = "book.json";
	public string Language { get; set; } = "pl";
    public int LastUsedId { get; set; } = 0;
    public string DefaultSortField { get; set; } = "Title";
    public string DefaultSortOrder { get; set; } = "Ascending";
    public DateTime LastOpened { get; set; } = DateTime.Now;

    public AppConfig() { }

	public static AppConfig Instance
	{
		get
		{
			lock (_lock)
			{
				return _instance ??= LoadConfig();
			}
		}
	}

    private static AppConfig LoadConfig()
	{
		const string configPath = "config.json";
		if (!File.Exists(configPath)) 
		{
			var defaultConfig = new AppConfig();
			defaultConfig.SaveConfig();
			return defaultConfig; 
		}
		var json = File.ReadAllText(configPath);
		return JsonSerializer.Deserialize<AppConfig>(json, JsonHelper.Options) ?? new AppConfig();
	}

	public void SaveConfig()
	{
		var json = JsonSerializer.Serialize(this, JsonHelper.Options);
		File.WriteAllText("config.json", json);
	}

	public int GetNextId()
	{
		LastUsedId++;
		SaveConfig();
		return LastUsedId;
	}
}
