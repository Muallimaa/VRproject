using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float rotationSpeed = 90.0f; // Kecepatan rotasi karakter
    public float raycastDistance = 1.0f; // Jarak raycast untuk pemeriksaan tabrakan
    public LayerMask obstacleLayer; // Layer penghalang yang ingin dihindari

    private OVRCameraRig cameraRig;

    private void Start()
    {
        cameraRig = GetComponent<OVRCameraRig>();
    }

    private void Update()
    {
        // Mendapatkan input dari thumbstick kiri
        Vector2 thumbstickInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // Menghitung vektor pergerakan berdasarkan input thumbstick kiri
        Vector3 moveDirection = new Vector3(thumbstickInput.x, 0f, thumbstickInput.y);
        moveDirection = cameraRig.centerEyeAnchor.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        moveDirection.Normalize();

        // Menentukan target posisi karakter
        Vector3 targetPosition = transform.position + moveDirection * movementSpeed * Time.deltaTime;

        // Mengecek tabrakan menggunakan Raycast
        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, raycastDistance, obstacleLayer))
        {
            // Jika terdapat tabrakan, tidak melakukan pergerakan
            targetPosition = transform.position;
        }

        // Menggerakkan karakter dengan mengubah posisi transform
        transform.position = targetPosition;

        // Mendapatkan input dari thumbstick kanan
        Vector2 thumbstickRotation = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        // Menghitung rotasi karakter berdasarkan input thumbstick kanan
        Vector3 rotationEuler = new Vector3(0f, thumbstickRotation.x * rotationSpeed * Time.deltaTime, 0f);

        // Memutar karakter dengan mengubah rotasi transform
        transform.Rotate(rotationEuler);
    }
}
