using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTriggerPoint : MonoBehaviour
{
    public GameObject pointOnTrigger;
    public bool activePoint;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == pointOnTrigger.name)
        {

            activePoint = true;
            //Debug.Log("Pressed Trigger");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == pointOnTrigger.name)
        {

            activePoint = false;
            //Debug.Log("Pressed Trigger");
        }
    }
}

