using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    private const int EquippableCount = 5;
    public static Status Instance;
    public GameObject EquippedObject;
    public TMP_Text StatsObject;
    public TMP_Text LogsObject;
    private Item[] equipped = new Item[EquippableCount];
    private PlayerStats stats;
    private AdventureLog logs;

	private void Awake()
	{
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Status system should not exist more than once"); }
        WarnInvalidObject();
	}

    private void WarnInvalidObject()
    {
        if (EquippedObject == null) { Debug.LogError("Equipped gameobject is empty"); }
        if (StatsObject == null) { Debug.LogError("Stats gameobject is empty"); }
        if (LogsObject == null) { Debug.LogError("Logs gameobject is empty"); }
    }

    // TODO
	public void EquipItem()
	{

	}

    // TODO
	public void UnequipItem()
	{

	}

    // TODO
    public void StatChange()
    {

    }

    public void AddLog()
    {

    }

	private void UpdateStatus()
	{

	}

    // TODO
    public void SameGame()
    {

    }

    // TODO
    public void LoadGame()
    {

    }
}

[System.Serializable]
public class AdventureLog
{
    public List<string> logs = new List<string>();
}

[System.Serializable]
public class PlayerStats
{
    // TODO 
}

// This class is for data save and loading
[System.Serializable]
public class PlayerStatusData
{
    public AdventureLog Log;
    public PlayerStats Stats;
    public string[] Equipped;
}