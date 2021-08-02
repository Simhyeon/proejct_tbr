using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILocationHandler : MonoBehaviour, IRecoverable
{
    public TMP_Text LocationText;
    public GameObject InteractionObjects;

    public UINpcListHandler NpcList;
    public UIMerchListHandler MerchList;

    private void Awake() 
    {
		if (NpcList == null) { Debug.LogWarning("Npc List is empty"); }
		if (MerchList == null) { Debug.LogWarning("Merchandise List is empty"); }
        if (InteractionObjects == null) { Debug.LogWarning("Interactino object List is empty"); }
    }

    public void SetLocationText(string locationName)
    {
        LocationText.text = locationName;
    }

    public void SetAvailableNpcList()
    {
        NpcList.ShowNpclist(LocationSystem.Instance.GetAvailableNpcs(), this);
    }

    public void SetAvailableMerchList()
    {

    }

    public void EnableInteractionButtons(bool enable)
    {
        InteractionObjects.SetActive(enable);
    }

    public void EnableLocationText(bool enable)
    {
        LocationText.gameObject.SetActive(enable);
    }

    public void ReenableLocationUIs()
    {
        EnableInteractionButtons(true);
        EnableLocationText(true);
    }

    void IRecoverable.Recover()
    {
        ReenableLocationUIs();
    }
}