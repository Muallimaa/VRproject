using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftButton : MonoBehaviour
{
    public GameObject player;
    public Vector3 naik;
    public Vector3 turun;
    public Transform targetPosition;

    public void MoveToTargetUp()
    {

        //transform.position = targetPosition.position;
        //player.transform.position = new Vector3(7.961f, 4.398f, 7.158f);
        player.transform.position = naik;
    }

    public void MoveToTargetDown()
    {

        //transform.position = targetPosition.position;
        //player.transform.position = new Vector3(7.02f, 0.22f, 7.34f);
        player.transform.position = turun;
    }
}
