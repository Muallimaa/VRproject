using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class SnapToLocation : MonoBehaviour
{
    //boolean variable used to determine if the object is currently being held by the player
    private bool grabbed;

    //return true when the object is within the Snapzone radius
    private bool insideSnapZone;

    //Return true when the object has had it's location update
    public bool Snapped;

    //Set the specific part we want to snap to this location
    public GameObject ObjectPart;
    //Reference another object we can use to set rotation
    public GameObject SnapRotationReference;

    //Detects when the RocketPart game object has entered the snap zone radius
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ObjectPart)
        {
            insideSnapZone = true;
            Debug.Log("TriggerOn");
        }
    }



    //Detects when the Objectpart game object has left the snap zone radius
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == ObjectPart)
        {
            insideSnapZone = false;

            Debug.Log("TriggerOff");
        }
    }

    void SnapObject()
    {
        if (grabbed == false && insideSnapZone == true)
        {
            ObjectPart.gameObject.transform.position = transform.position;
            ObjectPart.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
        }
        else
        {
                    Snapped = false;
         }
        /*
        if (grabbed == true && insideSnapZone == false)
        {
            //ObjectPart.gameObject.transform.position = transform.position;
            //ObjectPart.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = false;
        }
        */
    }


    // Update is called once per frame
    void Update()
    {
        //grabbed = ObjectPart.GetComponent<OVRGrabbable>().isGrabbed;

        grabbed = ObjectPart.GetComponent<Grabbable>().TransferOnSecondSelection;

        SnapObject();
    }
}
