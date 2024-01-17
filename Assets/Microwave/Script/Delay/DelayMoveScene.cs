using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayMoveScene : MonoBehaviour
{
    //public GameObject delayTime;
    public string nameScene;

    public float timeDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveScene());
    }

    private IEnumerator MoveScene()
    {
        //delayTime.SetActive(false);
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(nameScene);
        //Application.LoadLevel(nameScene);

    }
}