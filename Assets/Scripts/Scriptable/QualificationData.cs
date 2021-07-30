using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QualificationData", menuName = "Project_TBR/QualificationData", order = 0)]
public class QualificationData : ScriptableObject 
{
    public string Type;    
    public string Content;
}