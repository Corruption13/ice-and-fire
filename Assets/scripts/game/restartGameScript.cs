using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGameScript : MonoBehaviour
{
    public void RestartLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RestartLevel();
        }
    }
}
