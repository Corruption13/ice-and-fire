using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{



    public void ToggleWorldShadows(Toggle toggle)
    {
        if(toggle.isOn)
            PlayerPrefs.SetInt("shadows", 1);
        else
            PlayerPrefs.SetInt("shadows", 0);
    }


}
