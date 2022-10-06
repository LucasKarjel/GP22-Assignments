using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector2 position;
    public GameObject TargetPrefab;
    public Target(float x, float y)
    {
        x = Random.Range(-8, 8);
        y = Random.Range(-4, 4);
        position = new Vector2(x, y);
    }
    public void CreateTarget()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(TargetPrefab,new Vector2(Random.Range(-8, 8), Random.Range(-8, 8)),transform.rotation);
    }
    private void Update()
    {
        CreateTarget();
    }
}
