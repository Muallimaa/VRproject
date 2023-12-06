using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointOnRunning : MonoBehaviour
{ 
    public GameObject[] pointOnActive;
    private bool pointAdd;
    private bool running = false;

    public UnityEvent onPressed, onReleased;
    void Update()
    {
        if (componentLaunch() == true && running == false)
        {
            onPressed?.Invoke();
            //Debug.Log(componentLaunch())

            running = true;
        }

        if (componentLaunch() == false && running == true)
        {
            onReleased?.Invoke();
            //Debug.Log(componentLaunch());

            running = false;
        }

    }

    private bool componentLaunch()
    {
        for (int i = 0; i < pointOnActive.Length; i++)
        {

            pointAdd = pointOnActive[i].GetComponent<ActiveTriggerPoint>().activePoint;
            if (pointAdd == false)
            {


                return false;


            }
        }
        return true;
    }

    
}
