using System;

public class AppConfig
{
	public int LastUsedId { get; set; } = 0;

	public int GetNextId()
	{
		LastUsedId++;
		return LastUsedId;
	}
}
