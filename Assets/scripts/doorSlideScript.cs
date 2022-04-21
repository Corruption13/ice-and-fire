using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSlideScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string open_direction = "Up";
    
    public float distance = 100f;
    public float time = 1f;
    public Rigidbody2D rb;
   
    

    private float moveVertical = 0f;
    private float moveHorizontal = 0f;
    private float speed = 100f;
    private float time_left;
    private int objects_already_pressing_button = 0;

    private void Start()
    {
        if (time == 0) time = 1f;
        speed = distance / time; 
    }

    void FixedUpdate()
    {
 
        if (time_left > 0)
        {
            time_left -= Time.deltaTime;
            rb.velocity = new Vector2(moveHorizontal * Time.deltaTime * speed, moveVertical * Time.deltaTime* speed);
        }
        else
        {
            EndSlide(); 
        }
    }

    public void OpenObject()
    {
        objects_already_pressing_button += 1;
        if (objects_already_pressing_button != 1) return;
        time_left = (time_left == 0) ? time : time - time_left;
        chooseXYValues(1);
    }

    public void CloseObject()
    {
        objects_already_pressing_button-=1;
        if (objects_already_pressing_button != 0) return;
        time_left = (time_left == 0) ? time : time - time_left;
        chooseXYValues(-1);
         
    }

  
    public void chooseXYValues(int dir = 1)
    {
        if (open_direction == "Up")
        {
            moveVertical = 1 * dir;
        }
        else if (open_direction == "Down")
        {
            moveVertical = -1 * dir;
        }
        else if (open_direction == "Left")
        {
            moveHorizontal = -1 * dir;
        }
        else if (open_direction == "Right")
        {
            moveHorizontal = 1 * dir;
        }
        else
        {
            Debug.Log("Invalid Input to SlideObject(), Accepted: Up, Down, Left, Right");
            EndSlide();
        }
    }

    private void EndSlide()
    {
        moveVertical = 0;
        moveHorizontal = 0;
        rb.velocity = Vector2.zero; 
    }

}
