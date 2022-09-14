using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
    }

    float spaceBetweenLines = 0.2f;
    // Update is called once per frame
    void Update()
    {
        //Clear background
        Background(50, 166, 240);

        //Draw our art/stuff, or in this case a rectangle
        Rect(1, 1, 3, 3);
        //Circle
        Stroke(0,255,255);
        Circle(14, 5, 4);
        //L
        Stroke(255);
        Line(4, 7, 4, 3);
        Line(4, 3, 6, 3);
        //K
        Line(8, 7, 8, 3);
        Line(8, 5, 10, 7);
        Line(8, 5, 10, 3);

        //Prepare our stroke settings
        Stroke(128, 128, 128, 64);
        StrokeWeight(0.5f);


        //Draw our scan lines
        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {
            //Increase y-cord each time loop run
            float y = i * spaceBetweenLines;

            //Draw a line from left side of screen to the right
            Line(0, y, Width, y);
        }
    }
}
