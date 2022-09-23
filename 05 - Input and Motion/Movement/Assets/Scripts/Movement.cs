using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ProcessingLite.GP21
{
    public float diameter = 2;
    public float speed = 5;
    public float velocity = 0;
    public float accelerate = 1;
    public float decelerate = 2;
    public float maxSpeed = 5;
    bool IsMoving = false;
    Vector2 circlePos;
    Vector2 lastInput;
    // Start is called before the first frame update
    void Start()
    {
        circlePos = new Vector2(Width / 2, Height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        Background(50, 166, 240);

        if (Input.anyKey)
        {
            IsMoving = true;
        }

        Vector2 RawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 SmoothInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (RawInput.magnitude != 0)
        {
        lastInput = SmoothInput;
        }
     
        //Constant velocity downwards
        //posY = posY - v * Time.deltaTime;


        if (RawInput.magnitude != 0)
        {
            velocity += accelerate * Time.deltaTime;
        }
        else if (RawInput.magnitude == 0)
        {
            velocity -= decelerate * Time.deltaTime;
        }

        if (velocity < 0)
            velocity = 0;

        if (velocity > maxSpeed)
            velocity = maxSpeed;
        
        circlePos += lastInput * velocity * Time.deltaTime;

        Circle(circlePos.x, circlePos.y, diameter);


        //if (IsMoving)
        //{
        //    if (vX > 5)
        //    {
        //        vX = 5;
        //    }
        //}
        //else if ()
        //else if (IsMoving == false)
        //{
        //    if (vX > 0)
        //        vX = vX - accelerate * Time.deltaTime;
        //    else if (vX < 0)
        //        vX = vX + accelerate * Time.deltaTime;

        //    if (IsMoving)
        //{
        //    if (vY > 5)
        //    {
        //        vY = 5;
        //    }
        //}
        //else if (IsMoving == false)
        //{
        //    if (vY > 0)
        //        vY = vY - decelerate * Time.deltaTime;
        //    else if (vY < 0)
        //        vY = vY + decelerate * Time.deltaTime;
        //}
        //Square(posX - 5, posY, 2);
    }
}
