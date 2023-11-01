using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPointActive : MonoBehaviour
{
    public GameObject pointOnTrigger;
    public bool activePoint;
    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
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
            onPressed?.Invoke();
            activePoint = true;
            Debug.Log("Pressed Trigger");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == pointOnTrigger.name)
        {
            onReleased.Invoke();
            activePoint = false;
            Debug.Log("Pressed Trigger");
        }
    }
}
