using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    private const int EquippableCount = 5;
    public static Status Instance;
    public UIEquippedHandler EquippedObject;
    public UIStathandler StatsObject;
    public UILogHandler LogsObject;

    private PlayerStatusData statusData = new PlayerStatusData();

    // Initializations
	private void Awake()
	{
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Status system should not exist more than once"); }
        WarnInvalidObject();
        Init();
	}

    private void WarnInvalidObject()
    {
        if (EquippedObject == null) { Debug.LogError("Equipped gameobject is empty"); }
        if (StatsObject == null) { Debug.LogError("Stats gameobject is empty"); }
        if (LogsObject == null) { Debug.LogError("Logs gameobject is empty"); }
    }

	private void Init()
	{
        EquippedObject.Init();
        StatsObject.Init();
	}

    private void Start() 
    {
        // TODO + Debug
        // In real scenario read from save data
        // LoadGame();
        DebugStatus();

		statusData.Equipped = new List<string>() { "TestItem1", "TestItem2", "TestItem3", "TestItem4", "TestItem5" };
        // Add equipped items one by one
        foreach (var item in statusData.Equipped)
        {
            UpdateEquippedItems(Variant.PLUS, item);
        }

        // Add log items one by one
        foreach (var item in statusData.Logs)
        {
            UpdateLog(item);
        }

        UpdateStats();
    }

    // Debuggings
    private void DebugStatus()
    {
		statusData = new PlayerStatusData();
        // UpdateEquippedItems();
    }

    // Real methods
    // TODO
	public void ChangeEquipment(Variant variant,string itemName)
	{
        if (variant == Variant.PLUS) 
        {
			var newItem = Database.Instance.GetItem(itemName);
			statusData.Equipped.Add(itemName);
        } else if (variant == Variant.MINUS)
        {
            statusData.Equipped.Remove(itemName);
        }

        UpdateEquippedItems(variant, itemName);
	}

    // TODO
    public void ChangeStat(StatType statType, int amount)
    {
        statusData.Stats.StatsMap[statType] += amount;
        UpdateStats();
    }

    public void ChangeLog(string log)
    {
        statusData.Logs.Add(log);
        UpdateLog(log);
    }

    // Update Methods
    // Desc : Update ui components according to data
    private void UpdateEquippedItems(Variant variant, string itemName)
    {
        if (variant == Variant.PLUS)
        {
            EquippedObject.Equip(itemName);
        } 
        else if (variant == Variant.MINUS)
        {
            EquippedObject.Equip(itemName);
        }
    }

    private void UpdateStats()
    {
        StatsObject.RenewStatText(statusData.Stats);
    }
    private void UpdateLog(string log)
    {
        LogsObject.AddNewLog(log);
    }

    // IO methods
    // Desc: Read from or write to a file
    // TODO
    public void SaveGame()
    {

    }

    // TODO
    public void LoadGame()
    {

    }
}

public enum StatType
{
    STR = 0,
    STM = 1,
    INT = 2,
    AGI = 3,
    DEX = 4,
    HEL = 5,
    STATCOUNT = 6
}

[System.Serializable]
public class PlayerStats
{
    public Dictionary<StatType, int> StatsMap = new Dictionary<StatType, int>() {
        { StatType.STR, 0},
        { StatType.STM, 0},
        { StatType.INT, 0},
        { StatType.AGI, 0},
        { StatType.DEX, 0},
        { StatType.HEL, 0}
    };
}

// This class is for data save and loading
[System.Serializable]
public class PlayerStatusData
{
    public List<string> Logs = new List<string>();
    public PlayerStats Stats = new PlayerStats();
    public List<string> Equipped = new List<string>();
}