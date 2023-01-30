using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            //Left side
            if (touch.position.x < Screen.width/2)
            {
                GetComponent<HingeJoint2D>().useMotor = true;
            }
            //Right side
            else if (touch.position.x > Screen.width/2)
            {

            }
        }
    }
}
