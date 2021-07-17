using System;
using UnityEngine;

[Serializable]
public enum DNodeType
{
	TEXT,
	SELECTION
}

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
	public string goToId;
}