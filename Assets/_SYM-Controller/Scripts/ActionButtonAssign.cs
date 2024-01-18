using SYM;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class ActionButtonAssign : MonoBehaviour
{
    public Button actionButton;
    public UnityEvent OnButtonPress;
    public void _AssignEvents() 
    {
        if (actionButton == null)
            actionButton = UI_Manager.Instance.actionButton;

        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(ActionButton);

        actionButton.gameObject.SetActive(true);
    }
    public void _CancelEvents() 
    {
        if (actionButton == null)
            actionButton = UI_Manager.Instance.actionButton;

        actionButton.onClick.RemoveAllListeners();
        actionButton.gameObject.SetActive(false);
    }
    private void ActionButton() 
    {
        if (OnButtonPress != null) OnButtonPress.Invoke();

        actionButton.gameObject.SetActive(false);
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("actionbtn");
        //gameObject.SetActive(false); // turns off the gameobject that this script is sitting on
    }
}
