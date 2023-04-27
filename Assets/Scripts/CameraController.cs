using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float height = 5f;
    public float smoothSpeed = 0.125f;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0f, height, distance);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Vector3 lookAtPosition = target.position + new Vector3(0f, 0.5f, 0f);
        transform.LookAt(lookAtPosition);
    }
}
