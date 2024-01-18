using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectivesCounter : MonoBehaviour
{
    public int totalObjectives, objectivesCompleted;
    public UnityEvent OnObjectiveComplete, OnAllObjectivesComplete;

    public void UpdateObjectiveCounter() 
    {
        objectivesCompleted++;
        if(objectivesCompleted < totalObjectives) 
        {
            if(OnObjectiveComplete != null) OnObjectiveComplete.Invoke();
        }else if(objectivesCompleted >= totalObjectives) 
        {
            if (OnAllObjectivesComplete != null) OnAllObjectivesComplete.Invoke();

        }
    }
}
