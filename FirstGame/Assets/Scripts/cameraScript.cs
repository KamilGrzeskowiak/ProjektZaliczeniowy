using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public float horizontalOffset = 2f;

    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + initialOffset;

            float horizontalMovement = Input.GetAxis("Horizontal");
            Vector3 horizontalOffsetVector = Vector3.right * horizontalMovement * horizontalOffset;

            targetPosition += horizontalOffsetVector;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
