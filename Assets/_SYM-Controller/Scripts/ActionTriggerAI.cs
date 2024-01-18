using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ActionTriggerAI : MonoBehaviour
{
    Animator animatorAI;
    private int actionLayer;
    public string action;

    // Start is called before the first frame update
    void Start()
    {
        animatorAI = GetComponent<Animator>();
        actionLayer = animatorAI.GetLayerIndex("Action");

        SetAction();
    }

    public void SetAction()
    {
        animatorAI.CrossFade(action, 0.2f, actionLayer);
    }
    public void SetAction(string action)
    {
        animatorAI.CrossFade(action, 0.2f, actionLayer);
    }
}
