using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquippedHandler : MonoBehaviour
{
    private List<GameObject> itemObjects = new List<GameObject>();
    private Dictionary<string, int> nameIndexMap = new Dictionary<string, int>();
    private List<bool> slotAvailable = new List<bool>();

    private void Awake() {
        foreach (Transform child in transform)
        {
            itemObjects.Add(child.gameObject);
        }
    }
    public void Equip(string itemName)
    {
        for (int i = 0; i < itemObjects.Count; i++)
        {
            if (slotAvailable[i] == true)
            {
                itemObjects[i].GetComponent<RawImage>().texture = Database.Instance.GetItem(itemName).Icon;
                nameIndexMap.Add(itemName, i);
            }
        }
    }

    public void Unequip(string itemName)
    {
        var index = nameIndexMap[itemName];
		itemObjects[index].GetComponent<RawImage>().texture = null;
		nameIndexMap.Remove(itemName);
        slotAvailable[index] = false;
    }
}
