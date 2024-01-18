using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYM;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public bool isPlayer = true;
    public ActionTriggerAI AI;
    public CinematicFocus CineFocus;
    public List<DialogueClass> dialogues = new List<DialogueClass>();
    public UnityEvent OnDialoguesEnd;

    public void _TriggerDialogue()
    {
        DialogueManager.Instance.DuplicateDialogues(isPlayer, AI, dialogues, this);
        if (CineFocus != null) CineFocus._SetCinematicFocus();
    }

    public void DlgEnd()
    {
        if (CineFocus != null) CineFocus._EndCinematicFocus();

        if (isPlayer)
            InstanceManager.Instance.SetAction("Null");
        else
            AI.SetAction("Null");

        if (OnDialoguesEnd != null)
            OnDialoguesEnd.Invoke();
    }
}
