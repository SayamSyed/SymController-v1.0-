
using UnityEngine;
using UnityEngine.Events;

public class CustomEventTriggers : MonoBehaviour
{
    public UnityEvent OnAwakeEvent, OnStartEvent, OnEnableEvent, OnDisableEvent;
    // Start is called before the first frame update
    void Awake()
    {
        if (OnAwakeEvent != null)
            OnAwakeEvent.Invoke();
    }

    void Start()
    {
        if (OnStartEvent != null)
            OnStartEvent.Invoke();
    }

    void OnDisable()
    {
        if (OnDisableEvent != null)
            OnDisableEvent.Invoke();
    }

    void OnEnable()
    {
        if (OnEnableEvent != null)
            OnEnableEvent.Invoke();

    }

}
