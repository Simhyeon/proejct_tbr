using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogHandler : MonoBehaviour
{
    public GameObject UIComponentPrefab;

    // Removing log doesn't work
    public void AddNewLog(string log)
    {
        GameObject logObject = Instantiate(UIComponentPrefab, transform);
        logObject.GetComponent<TMPro.TMP_Text>().text = log;
    }
}
