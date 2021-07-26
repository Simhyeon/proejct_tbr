using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Debugger))]
public class DebuggerEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		Debugger debugger = (Debugger)target;
		if (GUILayout.Button("Trigger dialogue"))
		{
			debugger.ShowDialogue();
		}
		if (GUILayout.Button("Toggle status"))
		{
			debugger.ToggleStatus();
		}
		if (GUILayout.Button("Toggle inventory"))
		{
			debugger.ToggleInventory();
		}
		if (GUILayout.Button("Add item"))
		{
			debugger.AddItem();
		}
		if (GUILayout.Button("Remove item"))
		{
			debugger.RemoveItem();
		}
    }
}

public class Debugger : MonoBehaviour
{
    [Header("Target data")]
    public DialogueData TargetDialogue;
    public string ItemName;
    [Header("Target gameobjects")]
    public GameObject StatusObject;
    public GameObject InventoryObject;

    // Functions
    public void ShowDialogue()
    {
        Dialogue.Instance.TriggerDialogue(TargetDialogue);
    }
    public void ToggleStatus()
    {
        StatusObject.SetActive(!StatusObject.activeSelf);
    }
    public void ToggleInventory()
    {
        InventoryObject.SetActive(!InventoryObject.activeSelf);
    }
    public void AddItem()
    {
        Inventory.Instance.AddItem(ItemName);
    }

    public void RemoveItem()
    {
        Inventory.Instance.RemoveItem(ItemName);
    }
}
