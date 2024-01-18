using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayTriggerEvent : MonoBehaviour
{
    public float delay;
    public UnityEvent DelayEvent;
    public void TriggerDelayEvent()
    {
        StartCoroutine(DelayRoutine());
    }
    IEnumerator DelayRoutine() 
    {
        yield return new WaitForSeconds(delay);
        if (DelayEvent != null)
            DelayEvent.Invoke();
    }
}
