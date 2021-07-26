using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script determines whether to start a "new" game or dispalay necessary information for once.
public class GameStartHandler : MonoBehaviour
{
    private string path = "";
    public static GameStartHandler Instance;

	private void Awake()
	{
        // Prevent from getting destroyed
        DontDestroyOnLoad(gameObject);
		if (Instance == null) { Instance = this; }
		else { Debug.LogError("GameStarthandler should not exist more than once."); }

        path = Application.persistentDataPath;
	}

    // This is called by game start button
    public void GameStart()
    {
        // Load Game Data
    }

    private void LoadGame()
    {

    }
}
