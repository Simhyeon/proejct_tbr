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
	public string Id = null;
	public DNodeType NodeType = DNodeType.TEXT;
	public string Speaker = "";
	public string NodeText = "";
	public SelectionBranch[] Selections;
	public DialogueBranch[] Branches;
	public string GoToId = null;
}