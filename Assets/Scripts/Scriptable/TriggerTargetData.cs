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
                Debug.Log("Check player status");
                return ((ITriggerTarget)PlayerStatusSystem.Instance).Qualify(qualification);
            case TriggerTarget.LocationSystem:
                Debug.Log("Check location status");
				break;
            case TriggerTarget.InventorySystem:
                Debug.Log("Check inventory");
                return ((ITriggerTarget)InventorySystem.Instance).Qualify(qualification);
            default:
				break;
        }
        Debug.Log("Return false");
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