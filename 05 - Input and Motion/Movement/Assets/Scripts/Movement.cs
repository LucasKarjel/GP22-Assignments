using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ProcessingLite.GP21
{
    float posX;
    float posY;
    float diameter = 2;
    float speed = 5;
    float vX = 0;
    float vY= 0;
    int a = 1;
    bool IsMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        posX = Width / 2;
        posY = Height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Background(50, 166, 240);

        if (Input.anyKey)
        {
            IsMoving = true;
        }
        vY += Input.GetAxisRaw("Vertical") * Time.deltaTime;
        vX += Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        Vector2 vel = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        Vector2 move = new Vector2(vX, vY).normalized * Time.deltaTime;

        
        new Vector2(vX, vY);

        posX += vX * speed * Time.deltaTime;
        posY += vY * speed * Time.deltaTime;
        
        //Constant velocity downwards
        //posY = posY - v * Time.deltaTime;

        Circle(posX, posY, diameter);

        if (IsMoving)
        {
            if (vX > 5)
            {
                vX = 5;
            }
        }
        else if (IsMoving == false)
        {
            if (vX > 0)
                vX = vX - a * Time.deltaTime;
            else if (vX < 0)
                vX = vX + a * Time.deltaTime;
            //if (v > 0)
            //v -= a * Time.deltaTime;
        }
        if (IsMoving)
        {
            if (vY > 5)
            {
                vY = 5;
            }
        }
        else if (IsMoving == false)
        {
            if (vY > 0)
                vY = vY - a * Time.deltaTime;
            else if (vY < 0)
                vY = vY + a * Time.deltaTime;
            //if (v > 0)
            //v -= a * Time.deltaTime;
        }
        Square(posX - 5, posY, 2);
    }
}
