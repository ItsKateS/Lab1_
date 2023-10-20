using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishEnter : MonoBehaviour
{
    public GameObject victoryPanel;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.CompareTag("Player")) == true)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
