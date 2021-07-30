using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TriggerTargetData", menuName = "Project_TBR/TriggerTargetData", order = 0)]
public class TriggerTargetData : ScriptableObject 
{
    public TriggerTarget Target;

    public bool CheckQualification(QualificationData qualification)
    {
        switch (Target)
        {
            case TriggerTarget.PlayerStatusSystem:
                return PlayerStatusSystem.Instance.GetComponent<ITriggerTarget>().Qualify(qualification);
            case TriggerTarget.LocationSystem:
				break;
            case TriggerTarget.InventorySystem:
				break;
            default:
				break;
        }
        return false;
    }
}

[Serializable]
public enum TriggerTarget
{
	PlayerStatusSystem,
	LocationSystem,
	InventorySystem,
}