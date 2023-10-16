using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public Transform respawnPoint; // Pastikan Anda menghubungkan objek respawnPoint melalui Inspector
    private Rigidbody rb;
    public float respawnDelay = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < -0.01f)
        {
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            if (respawnDelay > 0)
            {
                Invoke("Respawn", respawnDelay);
            }
        }
    }

    private void Respawn()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Periksa apakah respawnPoint telah dihubungkan sebelum menggunakan
        if (respawnPoint != null)
        {
            // Reset posisi dan rotasi ke respawnPoint
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
        }
        else
        {
            Debug.LogWarning("Respawn Point belum dihubungkan!");
        }
    }
}
