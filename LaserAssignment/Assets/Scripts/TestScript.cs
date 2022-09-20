using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject laser;
    public float x = 1;
    public float y = 1;
    public float z = 1;
    public float size = 1;
    public float angle;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(laser, transform.position, transform.rotation);
        }
        
        //Move
        x += Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5;
        y += Input.GetAxisRaw("Vertical") * Time.deltaTime * 5;

        transform.position = new Vector3(x, y, 0);

        //Adjust scale
        if (Input.GetKeyDown(KeyCode.E))
        {
            size++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            size--;
        }

        Vector2 aim = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        transform.up = aim;
        

        transform.localScale = Vector2.one * size;
    }
}
