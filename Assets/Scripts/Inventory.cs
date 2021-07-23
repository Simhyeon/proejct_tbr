using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public GameObject InventoryObject;
    public Dictionary<string, Item> InventoryData;

    private void Awake() 
    {
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Inventory system should not exist more than once"); }
        if (InventoryObject == null) { Debug.LogError("Invetory gameobject is empty"); }
    }

    public void RemoveItem(Item item)
    {
        InventoryData.Add(item.name, item);
        UpdateInventory(item);
    }

    public void AddItem(Item item)
    {
        InventoryData.Remove(item.name);
        UpdateInventory(item);
    }

    // TODO 
    private void UpdateInventory(Item item)
    {

    }
}