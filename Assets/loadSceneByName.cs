using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneByName : MonoBehaviour
{
    public string scene_name="0"; 

    public void LoadSceneByName()
    {
        
        if (Application.CanStreamedLevelBeLoaded(scene_name))
        {
            SceneManager.LoadScene(scene_name);
        }
        else
        {
            Debug.LogError("Invalid Scene Name Given"); 
        }


    }
}
