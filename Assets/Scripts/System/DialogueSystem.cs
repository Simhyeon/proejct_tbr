using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
	public static DialogueSystem Instance;
	private DialogueData originalData;
	public Dictionary<string, int> DataIndex;
    private int CurrentIndex = 0;
	public UIDialogueHandler DialogueBox;

	public IRecoverable RecoverTarget;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Dialogue system should not exist more than once");
		}

		// Initialization
		DataIndex = new Dictionary<string, int>();
	}

	private void UpdateData(DialogueData data)
	{
		if (originalData == data)
		{
			Debug.LogError("Same dialogue data is assigned this is not intended behaviour.");
			return;
		}
		originalData = data;
		DataIndex = new Dictionary<string, int>();
		for(int i = 0; i < originalData.Nodes.Length; i++)
		{
			var node = originalData.Nodes[i];
			var id = node.Id;
			if (id == "")
			{
				// This is some arbitrary process to create barely random id
				// Since this is not about security but making hashtable predictable,
				// it is sufficient.
				id = Random.Range(0, 100) + "-" + Random.Range(0, 100);
			}
			DataIndex.Add(id, i);
		}
	}

	public void TriggerDialogue(string dialogueId)
	{
		// Update 
		var dialogue = Database.Instance.GetDialogue(dialogueId);
		UpdateData(dialogue);

		// Trigger
		DialogueBox.gameObject.SetActive(true);
		// First node is always root node of dialogue data which is the first
		// node from Nodes
        CurrentIndex = 0;
		NodeBehaviour();
	}

	public void TriggerDialogue(DialogueData dialogue, IRecoverable recoverTarget)
	{
		// Update
		UpdateData(dialogue);

		// Trigger
		DialogueBox.gameObject.SetActive(true);
		RecoverTarget = recoverTarget;
		// First node is always root node of dialogue data which is the first
		// node from Nodes
        CurrentIndex = 0;
		NodeBehaviour();
	}

    private void DisplayNode()
    {
		var currentNode = originalData.Nodes[CurrentIndex];
		DialogueBox.SetNode(currentNode);
        switch (currentNode.NodeType)
        {
            case DNodeType.SELECTION:
				SelectionSystem.instance.TriggerSelection(currentNode);
                break;
            default:
                break;
        }
    }

    // TODO
    // Go to next node
    public void NextNode()
    {
		var currentNode = originalData.Nodes[CurrentIndex];
		if (currentNode.GoToId == "exit")
		{
			CurrentIndex = originalData.Nodes.Length;
		}
		else if ( currentNode.GoToId != null && currentNode.GoToId != "" && currentNode.GoToId.ToLower() != "null") 
		{
			Debug.Log("Next target is :" + currentNode.GoToId);
			if (!DataIndex.ContainsKey(currentNode.GoToId))
			{
				Debug.LogError("Current dialogue does not have proper redirection to other node");
			}
			CurrentIndex = DataIndex[currentNode.GoToId];
		}
		else
		{
			CurrentIndex += 1;
		}

		CheckNodeIndex();
		NodeBehaviour();
    }

	private void CheckNodeIndex()
	{
		if (CurrentIndex > originalData.Nodes.Length || CurrentIndex < 0)
		{
			Debug.LogError("Next node index is either, bigger than the length of given dialogue's length or smaller than 0");
			Debug.LogError("Ndex node index is : " + CurrentIndex);
		}
	}

	private void NodeBehaviour()
	{
		// End of dialogue
		if (CurrentIndex == originalData.Nodes.Length)
		{
			EndDialogue();
		}
		else
		{
			// Display node content into ui dialogue box
			DisplayNode();
		}
	}

	private void EndDialogue()
	{
		// Hide dialoguebox
		DialogueBox.gameObject.SetActive(false);
		RecoverTarget.Recover();
	}

	public void RedirectTo(string id)
	{
		CurrentIndex = DataIndex[id];
		CheckNodeIndex();
		NodeBehaviour();
	}
}
