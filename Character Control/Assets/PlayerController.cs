using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    private Rigidbody2D rbd2;

    void Start()
    {
        //Stores rigidbody2D component
        rbd2 = GetComponent<Rigidbody2D>();
        //Turns off gravity
        rbd2.gravityScale = 0;
    }
    void FixedUpdate()
    {
        float moveHori = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHori, moveVert);

        rbd2.AddForce(movement * speed);
    }
}
