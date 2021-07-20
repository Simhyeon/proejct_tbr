using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Project_TBR/DialogueData", order = 0)]
public class DialogueData : ScriptableObject
{
	[SerializeField]
	public DialogueNode[] Nodes;
}


[Serializable]
public class DialogueNode 
{
	public string Id;
	public DNodeType NodeType;
	public string Speaker;
	public string NodeText;
	public string[] Selections;
	public DialogueBranch[] Branches;
	public string GoToId;
}

[Serializable]
public class DialogueBranch
{
	public SystemType TargetSystem;
	public string Target;
	public string Qualification;
	public string GoToId;
}