using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katrolsnaping : MonoBehaviour
{
    public Transform targetObject;
    public float snappingThreshold = 0.5f;
    public GameObject objKatrol;
    private bool isSnapped = false;

    public GameObject taliIkat;

    public Animator animator;
    public string nameSetAnimatorNaik;
    public string nameSetAnimatorTurun;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.gameObject == objKatrol && !isSnapped)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);
            if (distanceToTarget < snappingThreshold)
            {
                SnapToTarget();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objKatrol && isSnapped)
        {
            UnsnapFromTarget();
        }
    }

    private void SnapToTarget()
    {
        //transform.position = targetObject.position;
        transform.parent = targetObject;
        GetComponent<Collider>().enabled = false;
        isSnapped = true;

        animator.SetTrigger(nameSetAnimatorNaik);
        // Tampilkan objek
        taliIkat.SetActive(true);
    }

    private void UnsnapFromTarget()
    {
        transform.parent = null;
        GetComponent<Collider>().enabled = true;
        isSnapped = false;

        animator.SetTrigger(nameSetAnimatorTurun);

        // Sembunyikan objek
        taliIkat.SetActive(false);
    }
}
