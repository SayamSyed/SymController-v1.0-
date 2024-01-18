using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYM;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    #region Singleton
    private static DialogueManager instance;
    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DialogueManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(DialogueManager).Name;
                    instance = obj.AddComponent<DialogueManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this as DialogueManager;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField]private List<DialogueClass> dupDialogues = new List<DialogueClass>();
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    private int totalDialogueCount, triggeredDialoguesCount;
    public Button continueBtn;
    private Animator player;
    private static DialogueTrigger dlgTrigger;
    private bool isPlayer = false;
    private ActionTriggerAI AI;

    private void Start()
    {
        GameManager.Instance.InitBehaviour += Init;
    }
    void Init() 
    {
        player = GameManager.Instance.player;
    }

    public void DuplicateDialogues(bool isplyr, ActionTriggerAI aiction, List<DialogueClass> lol, DialogueTrigger dt) 
    {
        totalDialogueCount = lol.Count;
        triggeredDialoguesCount = 0;
        dlgTrigger = dt;
        isPlayer = isplyr;
        AI = aiction;

        if(dupDialogues.Count > 0)
        dupDialogues.Clear();

        for (int i = 0; i < totalDialogueCount; i++)
        {
            dupDialogues.Add(lol[i]);
        }

        TriggerDialogue(dupDialogues[triggeredDialoguesCount].dialogueText, dupDialogues[triggeredDialoguesCount].action,  dupDialogues[triggeredDialoguesCount].OnDialogueTrigger);
    }
    private void TriggerDialogue(string msg, string action, UnityEvent dialogueEvent) 
    {
        ShowDialogue(msg);

        if (action != null && isPlayer == true)
            ShowAction(action);

        if (AI != null && isPlayer == false)
            AiActionPlay(action);

        if (dialogueEvent != null)
            dialogueEvent.Invoke();
    }
    public void ContinueButton() 
    {
        triggeredDialoguesCount++;

        if(triggeredDialoguesCount >= totalDialogueCount) 
        {
            DialogueEnd();
            return;
        }

        TriggerDialogue(dupDialogues[triggeredDialoguesCount].dialogueText, dupDialogues[triggeredDialoguesCount].action, dupDialogues[triggeredDialoguesCount].OnDialogueTrigger);
    }
    private void DialogueEnd() 
    {
        dialoguePanel.GetComponent<DOTweenAnimation>().DORestartAllById("dialogueCloseTween");

        dlgTrigger.DlgEnd();
    }
    void AiActionPlay(string aiaction) 
    {
        dlgTrigger.AI.SetAction(aiaction);
    }
     void ShowDialogue(string str)
    {
        dialogueText.text = str;
        dialoguePanel.GetComponent<DOTweenAnimation>().DORestartAllById("dialogueOpenTween");
    }
     void ShowAction(string action) 
    {
        player.GetComponent<ActionTrigger>().SetAction(action);
    }

}
