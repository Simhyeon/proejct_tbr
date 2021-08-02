using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PlayerStatusSystem : MonoBehaviour, ITriggerTarget
{
    private const int EquippableCount = 5;
    public static PlayerStatusSystem Instance;
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
            UpdateEquippedItems(Variant.Positive, item);
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
        if (variant == Variant.Positive) 
        {
			var newItem = Database.Instance.GetItem(itemName);
			statusData.Equipped.Add(itemName);
        } else if (variant == Variant.Negative)
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
        if (variant == Variant.Positive)
        {
            EquippedObject.Equip(itemName);
        } 
        else if (variant == Variant.Negative)
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

    // Interface methods

    bool ITriggerTarget.Qualify(QualificationData qualification)
    {
        switch (qualification.Type.ToLower())
        {
            case "log":
                Debug.Log("Check logs");
                // Didn't find a value in logs
				if (statusData.Logs.SingleOrDefault(item => item == qualification.Content) == null) 
                {
                    return false;
				} 
                else { return true; }
            case "equipped":
                // Didn't find a value in equipped
                Debug.Log("Check equippment");
                if (statusData.Equipped.SingleOrDefault(item => item == qualification.Content) == null)
                {
                    return false;
                }
                else { return true;}
            case "stat":
                // Stat rules are followed as 
                // +number
                // =number
                // -number
                // String
                break;
            default:
                break;
        }

        return false;
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