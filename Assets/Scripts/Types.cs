using System;
using System.Collections.Generic;

[Serializable]
public enum DNodeType
{
	TEXT,
	SELECTION
}

[Serializable]
public enum SystemType
{
	STATUS,
	INVENTORY,

}

[Serializable]
public class DialogueBranch
{
	public SystemType TargetSystem;
	public string Target;
	public string Qualification;
	public string GoToId;
}

[Serializable]
public class SelectionBranch : DialogueBranch
{
	public string Text;
}

[Serializable]
public enum ItemType
{
	EQUIPPABLE,
	CONSUMABLE,
	MISC
}

[Serializable]
public enum Variant
{
	PLUS,
	MINUS
}

// This class is for data save and loading
[System.Serializable]
public class PlayerData
{
    public PlayerStatusData StatusData;
    public Dictionary<string, LocationData> LocationMap;
}

[System.Serializable]
public class LocationData
{
	public string LocationName {get; set;}
	// TODO 
	// HMM this looks complicated
}

[System.Serializable]
public class PlayerStatusData
{
    public List<string> Logs = new List<string>();
    public PlayerStats Stats = new PlayerStats();
    public List<string> Equipped = new List<string>();
}