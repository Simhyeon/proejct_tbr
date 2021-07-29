using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    public GameObject InventoryObject;
    public GameObject ItemPrefab;
    public Dictionary<string, List<ItemSlot>> InventoryData = new Dictionary<string, List<ItemSlot>>();

    private void Awake() 
    {
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Inventory system should not exist more than once"); }
        if (InventoryObject == null) { Debug.LogError("Invetory gameobject is empty"); }
        if (ItemPrefab == null) { Debug.LogError("Item prefab is empty"); }
    }

    public void AddItem(string itemName)
    {
        var item = Database.Instance.GetItem(itemName);
        // Not first input
        if (InventoryData.ContainsKey(itemName))
        {
            if (item.Stackable)
            {
                InventoryData[itemName][0].ChangeCount();
            }
            else 
            {
				var slot = Instantiate(ItemPrefab, InventoryObject.transform).GetComponent<ItemSlot>();
				slot.SetData(item);
                InventoryData[itemName].Add(slot);
            }
        }
        else // first
        {
			var slot = Instantiate(ItemPrefab, InventoryObject.transform).GetComponent<ItemSlot>();
			slot.SetData(item);
            InventoryData.Add(itemName, new List<ItemSlot>(){slot});
        }
    }

    public void RemoveItem(string itemName)
    {
        if (!InventoryData.ContainsKey(itemName) || InventoryData[itemName].Count == 0) { Debug.LogError("Can't remove non-existent item"); return;}
        if (Database.Instance.GetItem(itemName).Stackable)
        {
            var slot = InventoryData[itemName][0];
            slot.ChangeCount(-1);
            if (slot.GetCount() <= 0) 
            {
				// Remove first inventory item
				Destroy(InventoryData[itemName][0].gameObject);
                InventoryData.Remove(itemName);
            }
        }
        else
        {
			// Remove first inventory item
			Destroy(InventoryData[itemName][0].gameObject);
			InventoryData[itemName].RemoveAt(0);
        }
    }
}