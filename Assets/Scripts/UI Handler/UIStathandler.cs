using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStathandler : MonoBehaviour
{
    private TMPro.TMP_Text[] statTexts;

	public void Init()
	{
        statTexts = GetComponentsInChildren<TMPro.TMP_Text>();
        if (statTexts.Length != (int)StatType.STATCOUNT)
        {
            Debug.LogError("Text components to display user stats are insufficient about : " + ((int)StatType.STATCOUNT - statTexts.Length));
        }
	}

    public void RenewStatText(PlayerStats stats)
    {
        statTexts[(int)StatType.STR].text = "STR : " + stats.StatsMap[StatType.STR];
        statTexts[(int)StatType.STM].text = "STM : " + stats.StatsMap[StatType.STM];
        statTexts[(int)StatType.INT].text = "INT : " + stats.StatsMap[StatType.INT];
        statTexts[(int)StatType.AGI].text = "AGI : " + stats.StatsMap[StatType.AGI];
        statTexts[(int)StatType.DEX].text = "DEX : " + stats.StatsMap[StatType.DEX];
        statTexts[(int)StatType.HEL].text = "HEL : " + stats.StatsMap[StatType.HEL];
    }
}
