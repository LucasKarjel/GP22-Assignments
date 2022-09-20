using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TargetFunction : MonoBehaviour
{
    public GameObject Target;
    public float posX;
    public float posY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posX = Random.Range(-8.0f, 8.0f);
            posY = Random.Range(-4.0f, 4.0f);
            var position = new Vector2(posX, posY);
            Instantiate(Target, position, Quaternion.identity);
        }
    }
}
