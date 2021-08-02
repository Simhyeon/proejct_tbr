using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINpcListHandler : MonoBehaviour
{
    public GameObject NpcButtonPrefab;

    private void Awake() 
    {
        if (NpcButtonPrefab == null) { Debug.LogError("Npc button prefab is not set");}
    }

    private void PurgeChildren()
    {
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
	}
    public void ShowNpclist(List<string> npcList, IRecoverable recoverable)
    {
        PurgeChildren();
        foreach(var npc in npcList)
        {
			var spawned = Instantiate(NpcButtonPrefab, transform);
			spawned.GetComponentInChildren<TMPro.TMP_Text>().text = npc;
            spawned.GetComponent<Button>().onClick.AddListener( () => {
                TriggerNpcDialogue(npc, recoverable);
                // This disables current gameobject which is npclist
                gameObject.SetActive(false);
            });
		}
    }

    public void TriggerNpcDialogue(string npcName, IRecoverable recoverable)
    {
        var dialogue = Database.Instance.GetNpc(npcName).GetAvailbleDialogue();
        DialogueSystem.Instance.TriggerDialogue(dialogue, recoverable);
    }
}
