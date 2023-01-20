using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothingY = 0.5f;
    [SerializeField] Vector3 offset;
    private Vector3 chaseY;


    void Update()
    {
        Vector3 targetPosition = player.position + new Vector3(player.position.x, offset.y, 0);

        chaseY = Vector3.Lerp(new Vector3(0f, transform.position.y, 0f), new Vector3(0f, targetPosition.y, 0f), smoothingY * Time.deltaTime);
        // Camera follows the player with specified offset position
        transform.position = new Vector3(transform.position.x, chaseY.y, offset.z);
    }
}
