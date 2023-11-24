using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    
    public Transform targetPosition;

    public void MoveToTargetPosition()
    {
       
        transform.position = targetPosition.position;
    }
}
