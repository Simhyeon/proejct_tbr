using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
	public static Dialogue Instance;
	private DialogueData originalData;
	public Dictionary<string, int> DataIndex;
    private int CurrentIndex = 0;
	public GameObject DialogueBox;
	private TMP_Text SpeakerText;
	private TMP_Text ContentText;

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
		if (DialogueBox != null)
		{
			// There should be two texts under
			SpeakerText = DialogueBox.GetComponentsInChildren<TMP_Text>()[0];
			ContentText = DialogueBox.GetComponentsInChildren<TMP_Text>()[1];
		}
		else
		{
			Debug.LogError("Dialogue system needs dialogue box gameobject to perform.");
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
		DialogueBox.SetActive(true);
		// First node is always root node of dialogue data which is the first
		// node from Nodes
        CurrentIndex = 0;
		NodeBehaviour();
	}

	public void TriggerDialogue(DialogueData dialogue)
	{
		// Update
		UpdateData(dialogue);

		// Trigger
		DialogueBox.SetActive(true);
		// First node is always root node of dialogue data which is the first
		// node from Nodes
        CurrentIndex = 0;
		NodeBehaviour();
	}

    private void DisplayNode()
    {
		var currentNode = originalData.Nodes[CurrentIndex];
		SpeakerText.text = currentNode.Speaker;
		ContentText.text = currentNode.NodeText;
        switch (currentNode.NodeType)
        {
            case DNodeType.SELECTION:
				Selection.instance.TriggerSelection(currentNode);
                break;
            default:
                break;
        }
    }

    // TODO
    // Go to next node
    private void NextNode()
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
			// Hide dialoguebox
			DialogueBox.SetActive(false);
		}
		else
		{
			DisplayNode();
		}
	}

	public void RedirectTo(string id)
	{
		CurrentIndex = DataIndex[id];
		CheckNodeIndex();
		NodeBehaviour();
	}
}
