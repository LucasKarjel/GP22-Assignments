using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We still need to inherence from ProcessingLite, so we get access to all functions
class Ball : ProcessingLite.GP21
{
    //Our class variables
    Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    int color1;
    int color2;
    int color3;
    float size;
    float radius;


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
        //checks if x and y positions are within area and invert velocity if they aren't
        if (position.y + radius > Height && velocity.y > 0 || position.y - radius < 0 && velocity.y < 0)
            velocity.y *= -1;
        else if (position.x + radius > Width && velocity.x > 0 || position.x - radius < 0 && velocity.x < 0)
            velocity.x *= -1;

        position += velocity * Time.deltaTime;
    }
    public bool CircleCollision()
    {
        float maxDistance = Player.diameter / 2 + size / 2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(Player.circlePos.x - position.x) > maxDistance || Mathf.Abs(Player.circlePos.y - position.y) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(Player.circlePos.x, Player.circlePos.y), new Vector2(position.x, position.y)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }
    public void GameOver()
    {
        Background(128);
        Stroke(255, 0, 0);
        //G
        Line(3, 6, 5, 6);
        Line(3, 6, 3, 4);
        Line(3, 4, 5, 4);
        Line(5, 4, 5, 5);
        Line(4, 5, 5.5f, 5);
        //A
        
    }
}