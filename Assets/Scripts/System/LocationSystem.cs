using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSystem : MonoBehaviour
{
    public static LocationSystem Instance;
    public LocationData CurrentLocationData {get; set;}
    public LocationStatus CurrentLocationStatus {get; set;}
    public UILocationHandler LocationUI;

    private List<string> availableNpcs = new List<string>();
    private List<string> availableMerchandise = new List<string>();

    private void Awake() 
    {
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Location system should not exist more than once"); }
    }

    public void SetLocation(string LocationName)
    {
        CurrentLocationData = Database.Instance.GetLocation(LocationName);
        // TODO Currently status is disabled 
        // CurrentLocationStatus = Database.Instance.GetLocationStatus(LocationName);

        UpdateLocation();
    }

    public void SetLocation(LocationData data)
    {
        CurrentLocationData = data;
        // TODO Currently status is disabled 
        // CurrentLocationStatus = Database.Instance.GetLocationStatus(data.LocationName);

        UpdateLocation();
    }

    private void UpdateLocation()
    {
        LocationUI.SetLocationText(CurrentLocationData.LocationName);

        foreach(var npcData in CurrentLocationData.Npcs)
        {
            // Find availble npc list
            if (npcData.IsDefault || npcData.NpcTrigger.IsTriggered()) { 
                availableNpcs.Add(npcData.NpcName); }
        }

        // TODO ::: Add availble merchandise
    }

    public List<string> GetAvailableNpcs()
    {
        return availableNpcs;
    }

}
