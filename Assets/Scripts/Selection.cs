using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public static Selection instance;
    public SelectionBox Box;

    private void Awake() {
        if (instance == null) 
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Selection should not exist more than once.");
        }

        if (Box == null)
        {
            Debug.LogError("Selection box is not set.");
        }
    }

    public void TriggerSelection(DialogueNode node)
    {
        Debug.Log("Triggering selection");
        if (node.NodeType != DNodeType.SELECTION)
        {
            Debug.LogError("Selection box requires node which has type SELECTION. Given node type is :" + node.NodeType);
        }

        if( node.Selections.Length == 0 )
        {
            Debug.LogError("Selection is empty. There is data to display as selection box.");
        }

        // Additional logics come here
        // -----
        //

        Box.Enable(node.Selections);
    }
}