using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStart : MonoBehaviour
{
    public GameObject delayTimeStart;

    public float timeDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayShow());
    }

    IEnumerator PlayShow()
    {
        //delayTime.SetActive(false);
        yield return new WaitForSeconds(timeDelay);
        delayTimeStart.SetActive(true);
        
    }

    

}
