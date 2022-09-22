using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ProcessingLite.GP21
{
    float posX = 0;
    float diameter = 2;
    float speed = 5;
    float posY;
    float v = 1;
    int a = 1;
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

        bool IsMoving = false;
        if (Input.anyKey)
        {
            IsMoving = true;
        }
        posX += Input.GetAxis("Horizontal") * speed * v * Time.deltaTime;
        posY += Input.GetAxis("Vertical") * speed * v * Time.deltaTime;
        
        //posX = posX - v * Time.deltaTime;
        //posY = posY - v * Time.deltaTime;
        Circle(posX, posY, diameter);

        if (IsMoving)
            if (v < 5)
            {
            v += a * Time.deltaTime;
            }
        else if (IsMoving == false)
            {
            v = 1;
            //if (v > 1)
            //v -= a * Time.deltaTime;
            }
        //Square(posX - 5, posY, 2);
    }
}
