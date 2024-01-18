using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public string triggerTag = "Player";
    [Tooltip("Assign methods to this Trigger")]
    public UnityEvent onTriggerEnter, onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == triggerTag) 
        {
            if(onTriggerEnter != null)
            onTriggerEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == triggerTag)
        {
            if(onTriggerExit != null)
                onTriggerExit.Invoke();
        }
    }
}
