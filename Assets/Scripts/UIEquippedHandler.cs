using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquippedHandler : MonoBehaviour
{
    private ItemSlot[] itemObjects;
    private Dictionary<string, int> nameIndexMap = new Dictionary<string, int>();
    private List<bool> slotAvailable = new List<bool>();

    public void Init() 
    {
        itemObjects = GetComponentsInChildren<ItemSlot>();

        for(int i = 0; i < itemObjects.Length; i++)
        {
            slotAvailable.Add(true);
        }
    }
    public void Equip(string itemName)
    {
        for (int i = 0; i < itemObjects.Length; i++)
        {
            if (slotAvailable[i] == true)
            {
                itemObjects[i].SetData(Database.Instance.GetItem(itemName));
                nameIndexMap.Add(itemName, i);
                slotAvailable[i] = false;
                return;
            }
        }
    }

    public void Unequip(string itemName)
    {
        var index = nameIndexMap[itemName];
		itemObjects[index].RemoveData();
		nameIndexMap.Remove(itemName);
        slotAvailable[index] = true;
    }
}
