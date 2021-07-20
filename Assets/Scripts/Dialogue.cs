using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
	public static Dialogue Instance;
	public DialogueData OriginalData;
	public Dictionary<string, int> DataIndex;
    private int CurrentIndex;
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

		// Debug
		UpdateData(OriginalData);
	}

	public void UpdateData(DialogueData data)
	{
		this.OriginalData = data;
		for(int i = 0; i < OriginalData.Nodes.Length; i++)
		{
			var node = OriginalData.Nodes[i];
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

	public void TriggerDialogue()
	{
		DialogueBox.SetActive(true);
		// First node is always root node of dialogue data which is the first
		// node from Nodes
        CurrentIndex = 0;
		NodeBehaviour();
	}

    private void DisplayNode()
    {
		var currentNode = OriginalData.Nodes[CurrentIndex];
		SpeakerText.text = currentNode.Speaker;
		ContentText.text = currentNode.NodeText;
        switch (currentNode.NodeType)
        {
            case DNodeType.SELECTION:
                // TODO 
                // Trigger selection script's function with selection array
                // argument
                break;
            default:
                break;
        }
    }

    // TODO
    // Go to next node
    public void NextNode()
    {
		var currentNode = OriginalData.Nodes[CurrentIndex];
		if ( currentNode.GoToId != null && currentNode.GoToId != "") 
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
		if (CurrentIndex > OriginalData.Nodes.Length || CurrentIndex < 0)
		{
			Debug.LogError("Next node index is either, bigger than the length of given dialogue's length or smaller than 0");
			Debug.LogError("Ndex node index is : " + CurrentIndex);
		}
	}

	private void NodeBehaviour()
	{
		// End of dialogue
		if (CurrentIndex == OriginalData.Nodes.Length)
		{
			// Hide dialoguebox
			DialogueBox.SetActive(false);
		}
		else
		{
			DisplayNode();
		}
	}
}
