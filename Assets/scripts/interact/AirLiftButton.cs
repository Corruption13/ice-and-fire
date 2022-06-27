using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLiftButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Updraft Airlift;
    private int objects_already_pressing_button = 0;
    public Animator animator;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        objects_already_pressing_button += 1;
        if (objects_already_pressing_button == 1)
        {
            Airlift.ToggleAirLift();
            animator.SetBool("isPressed", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objects_already_pressing_button -= 1;
        if (objects_already_pressing_button == 0)
        {
            animator.SetBool("isPressed", false);
            Airlift.ToggleAirLift();
        }
    }
    
}
