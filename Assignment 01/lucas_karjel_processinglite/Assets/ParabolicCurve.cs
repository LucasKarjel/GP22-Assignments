using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicCurve : ProcessingLite.GP21
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < 10; i++)
        {
            Stroke(0);
            float m = i % 3
            if (m==0)
            {
                Stroke(255,0,0);
            }

            float y = 10-i;
            float x = 1 + i;
            Line(0, y, x, 0);
        }
    }
}
