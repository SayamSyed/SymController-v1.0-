using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpThisTransform : MonoBehaviour
{
    public float speed = .5f;
    public Transform destination;
    private Vector3 startPos, endPos;
    private Quaternion startRot,endRot;
    private float fraction = 1;


    void LerpToTransform()
    {
        startPos = transform.position;
        endPos = destination.position;

        startRot = transform.localRotation;
        endRot = destination.localRotation;

        fraction = 0;
    }

    void Update()
    {
        if (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, fraction);
            transform.localRotation = Quaternion.Lerp(startRot, endRot, fraction);
        }
    }
}
