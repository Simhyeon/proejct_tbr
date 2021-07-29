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
[Serializable]
public class PlayerData
{
    public PlayerStatusData StatusData;
    public Dictionary<string, LocationData> LocationMap;
}

[Serializable]
public class LocationData
{
	public string Name {get; set;}
	// TODO 
	// HMM this looks complicated
	public LocationStatus Status {get; set;}

	public List<NPC> NPCs {get; set;}
	public List<Merchandise> Tradables {get; set;}
}

public class Merchandise
{

}

[Serializable]
public class PlayerStatusData
{
    public List<string> Logs = new List<string>();
    public PlayerStats Stats = new PlayerStats();
    public List<string> Equipped = new List<string>();
}

public interface ITriggerTarget
{
	public bool Qualify(string qualification);
}

// This use reflection to check qualification
[Serializable]
public class Trigger
{
	public string Target {get; set;}
	public string Qualification {get; set;}
}

[Serializable]
public class Event
{
	public Trigger EventTrigger;
	public DialogueData Dialogue;
}

public class NPC
{
	public string Name {get; set;}	
	public Dictionary<Trigger, DialogueData> Dialogues {get; set;}
	public NpcStatus Status {get; set;}
}