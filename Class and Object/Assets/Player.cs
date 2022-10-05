using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    Ball[] balls;
    int numberOfBalls = 10;
    public static float diameter = 1;
    public float speed = 5;
    public float velocity = 0;
    public float accelerate = 10;
    public float decelerate = 20;
    public float maxSpeed = 10;
    public static Vector2 circlePos;
    public Vector2 lastInput;
    public Vector2 rawInput;
    public Vector2 smoothInput;
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
        
        Vector2 rawInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 smoothInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        //Set arguments for velocity and boundaries for max speed
        if (rawInput.magnitude != 0)
        {
            lastInput = smoothInput;
        }
        if (rawInput.magnitude != 0)
        {
            velocity += accelerate * Time.deltaTime;
        }
        else if (rawInput.magnitude == 0)
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
        for (int i = 0; i < balls.Length; i++)
        {
            //If not colliding
            if (!balls[i].CircleCollision())
            {
                //Tell each ball to update it's position
                balls[i].UpdatePos();
                balls[i].Draw();
            }
            //If colliding
            else if (balls[i].CircleCollision())
            {
                //if colliding stop and show game over screen
                velocity = 0;
                balls[i].GameOver();
            }
        }
    }
}
