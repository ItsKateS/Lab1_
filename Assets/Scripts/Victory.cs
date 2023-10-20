using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void VictoryButton()
    {
        if (SceneManager.GetActiveScene().name != "Level02")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1;
        }

        else
        {
            SceneManager.LoadScene("Level01");
            Time.timeScale = 1;
        }
    }
}
