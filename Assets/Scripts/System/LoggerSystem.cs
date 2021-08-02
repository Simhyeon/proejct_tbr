using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerSystem : MonoBehaviour
{
    public static LoggerSystem Instance;
    public bool SaveLogToFile = false;

    public string LogFilePath;
    public string LogErrorFilePath;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Logger system cannot exist more than once");
        }
    }

    public void Log(string text)
    {
        Debug.Log(text);
        if (SaveLogToFile)
        {
            // Do Something
        }
    }

    public void LogError(string text)
    {
        Debug.LogError(text);
        if (SaveLogToFile)
        {
            // Do Something
        }
    }
}
