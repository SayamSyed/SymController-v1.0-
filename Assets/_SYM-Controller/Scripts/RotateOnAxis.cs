using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnAxis : MonoBehaviour
{
    public GameObject tire1, tire2, tire3, tire4;
    public float rotationValue;

    // Update is called once per frame
    void Update()
    {
        tire1.transform.Rotate(Vector3.right * (rotationValue*Time.deltaTime));
        tire2.transform.Rotate(Vector3.right * (rotationValue*Time.deltaTime));
        tire3.transform.Rotate(Vector3.right * (rotationValue*Time.deltaTime));
        tire4.transform.Rotate(Vector3.right * (rotationValue*Time.deltaTime));
    }
}
