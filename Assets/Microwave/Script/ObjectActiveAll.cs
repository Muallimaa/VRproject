using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveAll : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Objek yang akan diaktifkan
    public GameObject buttonToShow; // Tombol yang akan ditampilkan
    public GameObject infocanva;
    public GameObject toggleCanva;

    private void Update()
    {
        // Periksa apakah semua objek telah diaktifkan
        bool allActivated = true;
        bool offCanva = false;
        foreach (GameObject obj in objectsToActivate)
        {
            if (!obj.activeSelf)
            {
                allActivated = false;
               //offCanva = true;
                break;
            }
        }

        // Tampilkan tombol jika semua objek telah diaktifkan
        buttonToShow.gameObject.SetActive(allActivated);

        infocanva.gameObject.SetActive(allActivated);

       //toggleCanva.gameObject.SetActive(offCanva);
    }
}
