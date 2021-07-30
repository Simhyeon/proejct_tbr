using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public static Database Instance;
    public DialogueData[] Dialogues;
    public ItemData[] Items;
    public LocationData[] Locations;
    private Dictionary<string, DialogueData> DialogueDB = new Dictionary<string, DialogueData>();
    private Dictionary<string, ItemData> ItemDB = new Dictionary<string, ItemData>();

    private void Awake() 
    {
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Database system should not exist more than once"); return;}

        foreach (var item in Dialogues)
        {
            DialogueDB.Add(item.Id, item);
        }

        foreach (var item in Items)
        {
            ItemDB.Add(item.ItemName, item);
        }
    }

    public DialogueData GetDialogue(string id)
    {
        return DialogueDB[id];
    }

    public ItemData GetItem(string name)
    {
        return ItemDB[name];
    }
}