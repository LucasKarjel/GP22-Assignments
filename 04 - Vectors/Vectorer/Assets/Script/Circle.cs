using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : ProcessingLite.GP21
{
    public float diameter = 2f;
    public Vector2 circlePosition;
    public Vector2 oldPosition;
    public Vector2 lineMagnitude;
    public int colorValue = 0;
    public Vector2 velocity;
    public float time = 0.0f;
    public bool isMoving = false;
    public float radius;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        radius = diameter / 2;
        //Circle startpoint in middle of screen
        circlePosition.x = Width / 2;
        circlePosition.y = Height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate magnitude of line
        lineMagnitude = circlePosition - oldPosition;
        Background(0);

        //Move circle to mouse
        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            circlePosition.x = MouseX;
            circlePosition.y = MouseY;
            velocity = Vector2.zero;
        }

        //Redraws circle at right position
        Circle(circlePosition.x, circlePosition.y, diameter);

        //Update old position on click
        if (Input.GetMouseButtonDown(0))
        {
            oldPosition.x = circlePosition.x;
            oldPosition.y = circlePosition.y;
        }

        //Draw line
        if (Input.GetMouseButton(0))
        {
            Stroke(255, 0, 0);
            Line(oldPosition.x, oldPosition.y, circlePosition.x, circlePosition.y);
            Stroke(0, 0, 255);
        }
        //Shift color, set current position as old
        if (Input.GetMouseButtonUp(0))
        {
            velocity = lineMagnitude * speed;
            if (colorValue == 0)
            {
                colorValue = 255;
            }
            else
            {
                colorValue = 0;
            }
            Fill(128, colorValue, 128);
        }
        if (!Input.GetMouseButton(0) || velocity.magnitude != 0)
        {
            velocity -= velocity / 2 * Time.deltaTime;
        }

        if (circlePosition.y + radius > Height && velocity.y < 0 || circlePosition.y - radius < 0 && velocity.y > 0)
            velocity.y *= -1;
        else if (circlePosition.x + radius > Width && velocity.x < 0 || circlePosition.x - radius < 0 && velocity.x > 0)
            velocity.x *= -1;
        
        circlePosition -= velocity * Time.deltaTime;
    }
}
