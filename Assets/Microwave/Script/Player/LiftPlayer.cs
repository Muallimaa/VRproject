using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftPlayer : MonoBehaviour
{
    public CharacterController characterController;
    public Transform characterTransform;
    public float moveSpeed = 3f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterTransform = transform;

        if (characterController == null)
        {
            Debug.LogError("CharacterController is not attached to the GameObject.");
        }
    }

    public void OnButtonPress()
    {
        // Menggerakkan karakter ke atas
        Vector3 moveDirection = new Vector3(0f, 1f, 0f);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Menggerakkan posisi GameObject (Transform) ke atas
        characterTransform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}