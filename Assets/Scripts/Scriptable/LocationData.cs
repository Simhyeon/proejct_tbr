using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocationData", menuName = "Project_TBR/LocationData", order = 0)]
public class LocationData : ScriptableObject 
{
	public string LocationName;

	public List<NpcData> Npcs;
	public List<Merchandise> Tradables;
}