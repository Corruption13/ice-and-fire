using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTouchControlParent = true;
    void Start()
    {
        getTouchControlsState();
    }


    bool getTouchControlsState()
    {
        if (PlayerPrefs.GetInt("EnableTouchControls") == 1)
        {
            if (isTouchControlParent)
                this.gameObject.SetActive(true);
            return true;
        }
        else
        {
            if (isTouchControlParent)
                this.gameObject.SetActive(false);
            return true;
        }
    }

    public void ToggleTouchControlSettings()
    {
        if(getTouchControlsState())
            PlayerPrefs.SetInt("EnableTouchControls", 0);
        else
            PlayerPrefs.SetInt("EnableTouchControls", 1);

        PlayerPrefs.Save();
    }
}
