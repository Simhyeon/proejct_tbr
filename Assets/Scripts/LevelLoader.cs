using UnityEngine;
using UnityEngine.SceneManagement;

/// This script is used only by buttons
public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int sceneNumber) 
    {
        // BCH ::: Build scene exitst
		if (SceneManager.sceneCountInBuildSettings >= sceneNumber)
		{
			SceneManager.LoadScene(sceneNumber);
		}
        // BCH ::: Build scene doesn't exist, should panicy... but you know it's game panic is somewhat overkill
		else
		{
            Debug.LogError("There is no such build index");
		}
    }

    public void LoadNextLevel()
	{
		int sceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        LoadLevel(sceneNumber);
	}
}