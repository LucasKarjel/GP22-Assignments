using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : ProcessingLite.GP21
{
    float posX = 0;
    float diameter = 2;
    float speed = 5;
    float posY;
    float v = 0;
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
        posX += Input.GetAxisRaw("Horizontal") * speed * v * Time.deltaTime;
        posY += Input.GetAxisRaw("Vertical") * speed * v * Time.deltaTime;
        
        posX = posX - v * Time.deltaTime;
        posY = posY - v * Time.deltaTime;
        Circle(posX, posY, diameter);

        if (v < 10)
            v += a * Time.deltaTime;

        Square(posX - 5, posY, 2);
    }
}
