using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymFx : MonoBehaviour
{
    public float speed = 2f;
    private Vector3 startPos, endPos;
    private Quaternion startRot,endRot;
    private float fraction = 1;


    public void LerpToTransform(Transform destination)
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
