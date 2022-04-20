using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoorScript : MonoBehaviour
{
    public doorSlideScript doorscript; 
    public Animator animator;

    private int objects_already_pressing_button = 0; 


    void OnTriggerEnter2D()
    {
        objects_already_pressing_button += 1;
        if (objects_already_pressing_button == 1)
        {
            doorscript.OpenObject();
            animator.SetBool("isPressed", true);
        }
    }
    void OnTriggerExit2D()
    {
        objects_already_pressing_button -= 1;
        if (objects_already_pressing_button == 0)
        {
            animator.SetBool("isPressed", false);
            doorscript.CloseObject();
        } 
    }

}
