using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    START,
    ACTION,
    DIALOGUE,
    STATUS,
    INVENTORY
}

// This is thecnically a main class 
public class FlowHandler : MonoBehaviour
{
    public static FlowHandler instance;

    private void Awake() {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Flowhandler should not exist more than once.");
        }
    }
}
