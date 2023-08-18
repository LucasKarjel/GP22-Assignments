using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : MonoBehaviour
{
    public bool rightMotor = true;
    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch
            Vector2 touchPosition = touch.position; // Touch position in pixels

            // Convert touch position to normalized coordinates
            Vector2 normalizedTouchPosition = touchPosition / new Vector2(Screen.width, Screen.height);

            // Now you can use normalizedTouchPosition to determine left and right sides
            if (normalizedTouchPosition.x < 0.5f)
            {
                // Touch on the left side of the screen
                if (!rightMotor)
                {
                    GetComponent<HingeJoint2D>().useMotor = true;
                }
            }
            else 
            {
                // Touch on the right side of the screen
                if (rightMotor)
                {
                    GetComponent<HingeJoint2D>().useMotor = true;
                }
            }
        }
        else
        {
            GetComponent<HingeJoint2D>().useMotor = false;
        }




        //if (Input.touchCount == 1)
        //{
        //    var touch = Input.touches[0];
        //    //Left side
        //    if (touch.position.y < Screen.width / 2)
        //    {
        //        if (!rightMotor)
        //        {
        //            GetComponent<HingeJoint2D>().useMotor = true;
        //        }
        //    }
        //    //Right side
        //    if (touch.position.y > Screen.width / 2)
        //    {
        //        if (rightMotor)
        //        {
        //            GetComponent<HingeJoint2D>().useMotor = true;
        //        }
        //    }
        //    else if (Input.touchCount == 0)
        //        GetComponent<HingeJoint2D>().useMotor = false;
        //}
    }
}
