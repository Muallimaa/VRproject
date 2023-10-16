using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public GameObject objectTrigger;

    public UnityEvent onPressed, onReleased;
    public string namaScene;

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
        if (other.gameObject == objectTrigger)
        {
            //DontDestroyOnLoad(objectToKeep);
            SceneManager.LoadScene(namaScene);
        }
        //Debug.Log("Pressed Trigger");
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectTrigger)
        {
            onReleased.Invoke();
            //Debug.Log("Pressed Trigger");
        }
    }
}
