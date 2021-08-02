using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(fileName = "NpcData", menuName = "Project_TBR/NpcData", order = 0)]
public class NpcData : ScriptableObject 
{
    public string NpcName;
	public bool IsDefault = true;
	public Trigger NpcTrigger;
    public DialogueData DefaultDialogue;
    public List<Event> Events;

    // Can be some inventory or equiped items possibly.

    public DialogueData GetAvailbleDialogue()
    {
        // Get all triggerable dialogues which is ordered by orders of events
        List<DialogueData> dialogues = Events.OrderBy(e => e.Order).Select(e => e.GetTriggerable()).Where(e => e != null).ToList();
        if (dialogues.Count == 0 )
        {
            if (DefaultDialogue == null) { Debug.LogError("There is no triggerable dialogue and default dialogue is null");}

            return DefaultDialogue;
        }
        else
        {
            return dialogues[0];
        }
    }
}