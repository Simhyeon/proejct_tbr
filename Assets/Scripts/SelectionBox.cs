using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionBox : MonoBehaviour
{
    public GameObject SelectionButtonPrefab;
    private List<int> Ids = new List<int>();

    private void Awake() 
    {
        if (SelectionButtonPrefab == null)
        {
            Debug.LogError("Selection button prefab is empty");
        }
    }

    public void Enable(IList<SelectionBranch> selections)
    {
        foreach (var sel in selections)
        {
            var selectionButtonObject = Instantiate(SelectionButtonPrefab, transform);
            selectionButtonObject.GetComponentInChildren<TMP_Text>().text = sel.Text;
            var button = selectionButtonObject.GetComponent<Button>();
            button.onClick.AddListener( delegate {
                GetPlayerInput(sel.GoToId);
            });
        }
    }

    public void GetPlayerInput(string id)
    {
        // Remove all children
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

        // Send id(value) back to Dialogue system
        Dialogue.Instance.RedirectTo(id);
    }
}