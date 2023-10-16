using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPakai : MonoBehaviour
{
    public GameObject objectUse;
    public GameObject objectTriggerTo;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectTriggerTo)
        {
            objectUse.SetActive(false);
        }
    }
}
