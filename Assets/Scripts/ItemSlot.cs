using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private ItemData Data;
    // Start is called before the first frame update
    [SerializeField]
    private TMPro.TMP_Text itemStatus;
    [SerializeField]
    private TMPro.TMP_Text itemCount;
    private int currentCount = 0;

    public void SetData(ItemData data)
    {
        Data = data;
        GetComponentInChildren<RawImage>().texture = data.Icon;

        if (data.Stackable)
        {
            itemCount.text = (++currentCount).ToString();
        }
    }

    public void ChangeCount(int amount=1)
    {
        currentCount += amount;
        itemCount.text = currentCount.ToString();
    }

    public int GetCount()
    {
        return currentCount;
    }

    public void SetStatus(string status)
    {
        itemStatus.text = status;
    }

    public ItemData GetData()
    {
        return Data;
    }

    public void RemoveData()
    {
        Data = null;
        currentCount = 0;
        itemCount.text = null;
        itemStatus.text = null;
        GetComponentInChildren<RawImage>().texture = null;
    }
}
