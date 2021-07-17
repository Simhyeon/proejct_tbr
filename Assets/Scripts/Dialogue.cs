using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
	public static Dialogue Instance;
	public DialogueData OriginalData;
	public Dictionary<string, DialogueNode> Data;
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
	}

	public void UpdateData(DialogueData data)
	{
		this.OriginalData = data;
		foreach (var item in OriginalData.Nodes)
		{
			var id = item.Id;
			if (id == "")
			{
				// This is some arbitrary process to create barely random id
				// Since this is not about security but making hashtable predictable,
				// it is sufficient.
				id = Random.Range(0, 100) + "-" + Random.Range(0, 100);
			}
			Data.Add(id, item);
		}
	}

	public void TriggerDialogue()
	{
		DialogueBox.SetActive(true);
		// First node is always root node of dialogue data which is the first
		// node from Nodes
		DialogueNode firstNode = OriginalData.Nodes[0];
		SpeakerText.text = firstNode.Speaker;
		ContentText.text = firstNode.NodeText;
        switch (firstNode.NodeType)
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
}
