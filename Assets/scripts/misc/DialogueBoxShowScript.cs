using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxShowScript : MonoBehaviour
{

    public void ActivateBanner(GameObject gameObject) {
        gameObject.SetActive(true);
    }

    public void CloseBanner(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }


    
}
