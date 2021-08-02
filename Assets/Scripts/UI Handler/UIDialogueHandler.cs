using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDialogueHandler : MonoBehaviour
{
	public TMP_Text SpeakerText;
	public TMP_Text ContentText;
	private DialogueNode currentNode;

	private void Awake() {
		if (SpeakerText == null) { Debug.LogError("Speaker text is null ");}
		if (ContentText == null) { Debug.LogError("Content text is null ");}
	}

	public void SetNode(DialogueNode node)
	{
		currentNode = node;

		SpeakerText.text = currentNode.Speaker;
		ContentText.text = currentNode.NodeText;
	}

	public void OnClick()
	{
		if (currentNode.GoToId != null) {
			DialogueSystem.Instance.NextNode();
		}
	}
}