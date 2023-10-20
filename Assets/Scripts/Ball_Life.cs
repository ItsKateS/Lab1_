using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball_Life : MonoBehaviour
{
    bool dead = false;
    public GameObject restartPanel;

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BallController>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        Invoke(nameof(Restart), 1.3f);
        dead = true;
    }

    void Restart()
    {
        restartPanel.SetActive(true);
    }
}
