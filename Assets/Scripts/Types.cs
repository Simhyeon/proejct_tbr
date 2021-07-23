using System;

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