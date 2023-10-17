using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class SnapPoint : MonoBehaviour
{

    //Reference the snap zone collider we'll be using
    //public GameObject SnapLoction;

    //Reference the gme object that the snapped objects will become a part of
    public GameObject ObjectToSnap;

    //Create a variable that will be used by the Object Lunch script to determine if all therr pieces
    public bool isSnapped;

    //boolean variable used to reference the "Snapped" boolean from the SnapToLocation script
    private bool objectSnapped;

    //boolean variable used to determine if the object is currently being held by the player
    private bool grabbed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //set grabbed to equal the boolan value "isGrabbed" from the OVRGrabbable script
        //grabbed = GetComponent<OVRGrabbable>().isGrabbed;
        grabbed = GetComponent<Grabbable>().TransferOnSecondSelection;


        //Set objectSnapped equal to the Snapped boolean from SnapToLocation
        //objectSnapped = SnapLoction.GetComponent<SnapToLocation>().Snapped;

        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            //transform.SetParent(ObjectToSnap.transform);
            isSnapped = true;
            transform.SetParent(ObjectToSnap.transform);

        }

        if (objectSnapped == false && grabbed == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            transform.SetParent(null);
        }
    }
}

