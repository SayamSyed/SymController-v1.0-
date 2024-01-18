using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueClass 
{
    public string dialogueText;
    public string action;
    public UnityEvent OnDialogueTrigger;
}
