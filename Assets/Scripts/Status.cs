using System.Collections.Generic;

public class StatusBase
{
	public List<string> Logs {get; set;}
}

public class CharcterStatus : StatusBase
{
	public List<string> Posession {get; set;}
    public List<string> Equipped {get; set;}
}

public class NpcStatus : CharcterStatus
{

}

public class PlayerStatus : CharcterStatus
{
    public PlayerStats Stats {get; set;}
}

public class LocationStatus : StatusBase
{
	public Dictionary<string, ItemData> Merchandise {get; set;}
	// public List<Trigger, Yatti> Yatta {get; set;}
}