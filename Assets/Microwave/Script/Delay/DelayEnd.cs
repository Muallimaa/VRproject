using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayEnd : MonoBehaviour
{
    public GameObject delayTime;

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
        delayTime.SetActive(false);
        
    }
}
