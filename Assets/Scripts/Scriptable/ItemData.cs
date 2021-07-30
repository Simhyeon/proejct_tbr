using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Project_TBR/Item", order = 0)]
public class ItemData : ScriptableObject 
{
    public string ItemName;
    public ItemType Type;
    public bool Stackable; 
    // pubic int MaxStack;
    public Texture2D Icon;
}
