using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControler : MonoBehaviour
{
    public Transform targ;
    public float trailDistance = 5.0f;
    public float heightOffset = 3.0f;
    public float cameraDelay = 0.02f;

    void Update()
    {
        Vector3 followPos = targ.position - targ.forward * trailDistance;

        followPos.y += heightOffset;
        transform.position += (followPos - transform.position) * cameraDelay;

        transform.LookAt(targ.transform);
    }
}
