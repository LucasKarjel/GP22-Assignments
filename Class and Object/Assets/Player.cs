using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    Ball[] balls;
    int numberOfBalls = 10;
    public static float diameter = 2;
    public float speed = 5;
    public float velocity = 0;
    public float accelerate = 10;
    public float decelerate = 20;
    public float maxSpeed = 10;
    public static Vector2 circlePos;
    public Vector2 lastInput;
    // Start is called before the first frame update
    void Start()
    {
        circlePos = new Vector2(Width / 2, Height / 2);

        balls = new Ball[numberOfBalls];

        //A loop that can be used for creating multiple balls.
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball(Random.Range(1, 9), Random.Range(1, 9));
        }
    }
    // Update is called once per frame
    void Update()
    {
        Background(0);
        Vector2 RawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 SmoothInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        //Set arguments for velocity and boundaries for max speed
        if (RawInput.magnitude != 0)
        {
            lastInput = SmoothInput;
        }
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


        //Update player position
        Stroke(255, 0, 0);
        Fill(0);
        Circle(circlePos.x, circlePos.y, diameter);
        NoStroke();

        //If colliding stop drawing
        for (int i = 0; i < balls.Length; i++)
            if (balls[i].CircleCollision())
            {
                balls[i].GameOver();
                balls[i] = null;
            }

        //Tell each ball to update it's position
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
        }



        //Update player position
        //Tell each ball to update it's position
        //for (int i = 0; i < balls.Length; i++)
        // {
        //    if (!balls[i].CircleCollision())
        //    {
        //    Stroke(255, 0, 0);
        //    Fill(0);
        //    Circle(circlePos.x, circlePos.y, diameter);
        //    NoStroke();
        //     balls[i].UpdatePos();
        //     balls[i].Draw();
        //    }
        //    else
        //    {
        //        balls[i].GameOver();
        //    }
    }
}
