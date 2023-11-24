using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 90.0f; 
    public float raycastDistance = 1.0f; 
    public LayerMask obstacleLayer; 

    private OVRCameraRig cameraRig;

    private void Start()
    {
        cameraRig = GetComponent<OVRCameraRig>();
    }

    private void Update()
    {
        
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        
        Vector3 moveDirection = new Vector3(thumbstickInput.x, 0f, thumbstickInput.y);
        moveDirection = cameraRig.centerEyeAnchor.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        moveDirection.Normalize();

        
        Vector3 targetPosition = transform.position + moveDirection * movementSpeed * Time.deltaTime;

        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, raycastDistance, obstacleLayer))
        {
            
            targetPosition = transform.position;
        }

        
        transform.position = targetPosition;

        
        Vector2 thumbstickRotation = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        
        Vector3 rotationEuler = new Vector3(0f, thumbstickRotation.x * rotationSpeed * Time.deltaTime, 0f);

        
        transform.Rotate(rotationEuler);
    }
}
