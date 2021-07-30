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
		if (GUILayout.Button("Add log"))
		{
			debugger.AddLog();
		}
		if (GUILayout.Button("Trigger event"))
		{
            debugger.TriggerEvent();
		}
    }
}

public class Debugger : MonoBehaviour
{
    [Header("Target data")]
    public DialogueData TargetDialogue;
    [Header("Target event")]
    public Event TargetEvent;
    [Header("Target item")]
    public string ItemName;
    [Header("Target Log")]
    public string LogString;
    [Header("Target gameobjects")]
    public GameObject StatusObject;
    public GameObject InventoryObject;

    // Functions
    public void ShowDialogue()
    {
        DialogueSystem.Instance.TriggerDialogue(TargetDialogue);
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
        InventorySystem.Instance.AddItem(ItemName);
    }

    public void RemoveItem()
    {
        InventorySystem.Instance.RemoveItem(ItemName);
    }

    public void TriggerEvent()
    {
        var dialogue = TargetEvent.TriggerEvent();
        if (dialogue == null) { Debug.Log("Didn't qualify"); }
        else { DialogueSystem.Instance.TriggerDialogue(dialogue); }
    }

    public void AddLog()
    {
        PlayerStatusSystem.Instance.ChangeLog(LogString);
    }
}
