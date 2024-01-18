using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
using SYM;

public class CinematicFocus : MonoBehaviour
{
    #region Variables
    CinemachineBrain brain;

    public int focusTime =5;
    public bool endManually; 
    public bool controlsDisable = true; 
    public CinemachineVirtualCamera virtualCamera;
    public int priority = 11;
    public CinemachineBlendDefinition inBlend, outBlend;
    
    public UnityEvent OnFocusStart, OnFocusEnd;
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        virtualCamera.gameObject.SetActive(false);
    }
    void Start()
    {
        brain = CameraManager.Instance.brain;
        virtualCamera.Priority = priority;
    }

    public void _SetCinematicFocus() 
    {
        if (brain != null)
            brain.m_DefaultBlend = inBlend;

        virtualCamera.gameObject.SetActive(true);

        if (controlsDisable)
            UI_Manager.Instance.GameplayUIState(!controlsDisable);

        if (OnFocusStart != null)
            OnFocusStart.Invoke();

        StartCoroutine(BlendVirtualCam());
    }
    IEnumerator BlendVirtualCam() 
    {
        if (endManually) 
            yield break;

        yield return new WaitForSeconds(focusTime);
        virtualCamera.gameObject.SetActive(false);
        brain.m_DefaultBlend = outBlend;

        if (controlsDisable)
            UI_Manager.Instance.GameplayUIState(controlsDisable);

        if (OnFocusEnd != null)
            OnFocusEnd.Invoke();
    }
    public void _EndCinematicFocus() 
    {
        StopAllCoroutines();
        brain.m_DefaultBlend = outBlend;
        virtualCamera.gameObject.SetActive(false);

        if (OnFocusEnd != null)
            OnFocusEnd.Invoke();

        if(controlsDisable)
            UI_Manager.Instance.GameplayUIState(controlsDisable);
    }

}
