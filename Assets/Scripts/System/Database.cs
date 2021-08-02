using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    // There are files referenced from an editor.
    public static Database Instance;
    public DialogueData[] Dialogues;
    public ItemData[] Items;
    public LocationData[] Locations;
    public NpcData[] Npcs;

    // THis is status file read from a desginated save file
    private Dictionary<string, DialogueData> dialogueDB = new Dictionary<string, DialogueData>();
    private Dictionary<string, ItemData> itemDB = new Dictionary<string, ItemData>();
    private Dictionary<string, LocationData> locationDB = new Dictionary<string, LocationData>();
    private Dictionary<string,LocationStatus> locationStatuses = new Dictionary<string, LocationStatus>();
    private Dictionary<string,NpcData> npcDB = new Dictionary<string, NpcData>();
    private Dictionary<string,NpcStatus> npcStatuses = new Dictionary<string, NpcStatus>();

    private void Awake() 
    {
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Database system should not exist more than once"); return;}

        foreach (var item in Dialogues)
        {
            dialogueDB.Add(item.Id, item);
        }

        foreach (var item in Items)
        {
            itemDB.Add(item.ItemName, item);
        }

        foreach (var item in Locations)
        {
            locationDB.Add(item.LocationName, item);
        }

        foreach (var npc in Npcs)
        {
            npcDB.Add(npc.NpcName, npc);
        }
    }

    public void ReadStatusfile()
    {

    }

    public void SaveStatus()
    {

    }

    public DialogueData GetDialogue(string id)
    {
        return dialogueDB[id];
    }

    public ItemData GetItem(string name)
    {
        return itemDB[name];
    }

    public LocationData GetLocation(string name) 
    {
        return locationDB[name];
    }

    public LocationStatus GetLocationStatus(string name) 
    {
        return locationStatuses[name];
    }

    public NpcData GetNpc(string name) 
    {
        return npcDB[name];
    }

    public NpcStatus GeNpcStatus(string name) 
    {
        return npcStatuses[name];
    }
}