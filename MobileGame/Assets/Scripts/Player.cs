using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    private Vector3 pointerPos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //RaycastHit2D hit;

            Touch touch = Input.GetTouch(0);
            pointerPos = Camera.main.ScreenToWorldPoint(touch.position);
            pointerPos.z = 0;
            transform.position = pointerPos;
            if (Physics.Raycast(pointerPos, pointerPos + Vector3.forward, 100))
            {
            }
        }
    }
}
