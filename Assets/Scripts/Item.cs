using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Project_TBR/Item", order = 0)]
public class Item : ScriptableObject 
{
    public string Name;
    public ItemType Type;
    public Texture2D Icon;
}
