using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 pointerPos;
    public float jumpForce;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void FixedUpdate()      
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //RaycastHit2D hit;

            Touch touch = Input.GetTouch(0);
            pointerPos = Camera.main.ScreenToWorldPoint(touch.position);
            pointerPos.z = 0;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (Physics.Raycast(pointerPos, pointerPos + Vector3.forward, 100))
            {
            }
        }
    }
}
