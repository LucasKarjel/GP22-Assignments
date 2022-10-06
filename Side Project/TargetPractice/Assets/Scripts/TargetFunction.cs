using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TargetFunction : MonoBehaviour
{
    Target[] TargetSpawn;
    int MaxTargets = 3;
    // Start is called before the first frame update
    void Start()
    {
        TargetSpawn = new Target[MaxTargets];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
