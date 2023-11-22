using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPanel : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= 0)
        {
            this.gameObject.SetActive(false);
            currentTime = startingTime;
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
        }
    }
        
}
