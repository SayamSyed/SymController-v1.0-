using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Level : MonoBehaviour
{
    public Transform position;
    //public Transform carPosition; CAR CODE DRIVE
    public int reward;
    public UnityEvent OnInit, OnLevelComplete, OnLevelFail;
}
