using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite, so we get access to all functions
public class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    int color1;
    int color2;
    int color3;
    public float size;
    public float radius;

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y)
    {
        //Set our position when we create the code.
        position = new Vector2(x, y);
        //Set random color
        color1 = Random.Range(0, 255);
        color2 = Random.Range(0, 255);
        color3 = Random.Range(0, 255);
        NoStroke();
        //Set random size
        size = Random.Range(0.5f, 1f);
        radius = size / 2;
        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }
    //Draw our ball
    public void Draw()
    {
        Debug.Log(position);
        Fill(color1, color2, color3);
        Circle(position.x, position.y, size);
        Debug.Log(size);
    }

    //Update our ball
    public void UpdatePos()
    {
        if (position.y + radius > Height && velocity.y > 0 || position.y - radius < 0 && velocity.y < 0)
            velocity.y *= -1;
        else if (position.x + radius > Width && velocity.x > 0 || position.x - radius < 0 && velocity.x < 0)
            velocity.x *= -1;

        position += velocity * Time.deltaTime;
    }
}