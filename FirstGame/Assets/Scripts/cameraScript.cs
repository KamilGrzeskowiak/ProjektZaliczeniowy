using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;
    public float horizontalOffset = 2f;
    public float stopXPosition = 10f;

    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            if (target.position.x >= stopXPosition)
            {
                transform.position = new Vector3(stopXPosition + initialOffset.x, transform.position.y, transform.position.z);
            }
            else
            {
                Vector3 targetPosition = target.position + initialOffset;

                float horizontalMovement = Input.GetAxis("Horizontal");
                Vector3 horizontalOffsetVector = Vector3.right * horizontalMovement * horizontalOffset;

                targetPosition += horizontalOffsetVector;

                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }
    }
}
