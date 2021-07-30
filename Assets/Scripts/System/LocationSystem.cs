using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSystem : MonoBehaviour
{
    public static LocationSystem Instance;
    public LocationData CurrentLocation;

    private void Awake() 
    {
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("Location system should not exist more than once"); }
    }

    public void SetLocation(string LocationName)
    {
        
    }
}
