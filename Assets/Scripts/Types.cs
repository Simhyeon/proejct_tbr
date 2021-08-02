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
	Positive,
	Negative
}

// This class is for data save and loading
[Serializable]
public class PlayerData
{
    public PlayerStatusData StatusData;
    public Dictionary<string, LocationData> LocationMap;
}

[Serializable]
public class Merchandise
{
	public Trigger ItemTrigger;
	public ItemData Data;
}

[Serializable]
public class PlayerStatusData
{
    public List<string> Logs = new List<string>();
    public PlayerStats Stats = new PlayerStats();
    public List<string> Equipped = new List<string>();
}

// This is an interface that can be targetted by the trigger class
public interface ITriggerTarget
{
	bool Qualify(QualificationData qualification);
}

// THis is an interface that can be recovered to
// e.g.  after dialogue end, IRecoverable can be recovered
public interface IRecoverable
{
	void Recover();
}

// This use reflection to check qualification
[Serializable]
public class Trigger
{
	public TriggerTargetData TargetData;
	public QualificationData Qualification;

	public bool IsTriggered()
	{
		return TargetData.CheckQualification(Qualification);
	}
}

[Serializable]
public class Event
{
	// This only affects when multiple events are evaludated
	public int Order;
	public Trigger TargetTrigger;
	public DialogueData Dialogue;

	public DialogueData GetTriggerable()
	{
		if (TargetTrigger.IsTriggered())
		{
			return Dialogue;
		}
		else
		{
			return null;
		}
	}
}

[Serializable]
public class Npc
{
	public string Name { get { return Data.NpcName; }}
	public NpcData Data;
	public NpcStatus Status;
}