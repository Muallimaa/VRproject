using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class SnapPoint : MonoBehaviour
{
    //Reference the snap zone collider we'll be using
    public GameObject SnapLocation;

    //Reference the gme object that the snapped objects will become a part of
    public GameObject ObjectToSnap;

    //Create a variable that will be used by the Object Lunch script to determine if all therr pieces
    public bool isSnapped;

    //boolean variable used to reference the "Snapped" boolean from the SnapToLocation script
    private bool objectSnapped;

    //boolean variable used to determine if the object is currently being held by the player
    private bool grabbed;

    //public GameObject chekSceneList;

    public SnapToLocation snapObject;

    // Start is called before the first frame update
    void Start()
    {
        //chekSceneList.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //set grabbed to equal the boolan value "isGrabbed" from the OVRGrabbable script
        //grabbed = GetComponent<OVRGrabbable>().isGrabbed;
        grabbed = GetComponent<Grabbable>().TransferOnSecondSelection;


        //Set objectSnapped equal to the Snapped boolean from SnapToLocation
        objectSnapped = SnapLocation.GetComponent<SnapToLocation>().Snapped;

        if (objectSnapped == true && grabbed == false)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            transform.SetParent(ObjectToSnap.transform);
            isSnapped = true;
        }

        if (grabbed == true)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            snapObject.Snapped = false;
            isSnapped = false;

            transform.SetParent(null); // Unparent the object
        }
        else if (isSnapped && !objectSnapped)
        {
            //GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<Rigidbody>().useGravity = true;
            isSnapped = false;
            transform.SetParent(null); // Unparent the object
        }
    }
}
