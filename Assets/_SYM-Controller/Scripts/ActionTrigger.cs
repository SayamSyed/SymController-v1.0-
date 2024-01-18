using SYM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTrigger : MonoBehaviour
{
    private Animator playerAnim;
    private int actionLayer;
    public string animState;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GameManager.Instance.player;
        actionLayer = playerAnim.GetLayerIndex("Action");
    }

    public void SetAction() 
    {
        playerAnim.CrossFade(animState, 0.2f, actionLayer);
    }
    public void SetAction(string action)
    {
        playerAnim.CrossFade(action, 0.2f, actionLayer);
    }
}
