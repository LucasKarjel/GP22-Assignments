using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class PlayerShoot : AttributesSync
{
    [SynchronizableField] public int health = 100;

    [SerializeField] private int damage = 10;
    public Alteruna.Avatar avatar;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int playerSelfLayer;

    private Transform mainCam;


    private void Start()
    {
        mainCam = Camera.main.transform;
        if (!avatar.IsMe)
        {
            avatar.gameObject.layer = playerSelfLayer;
        }
    }
    private void Update()
    {
        if (!avatar.IsMe)
        {
            return;
        }

        if (InputManager.Instance.PlayerShotThisFrame())
        {
            Shoot();
        }

        //Vector3 cameraRotation = mainCam.rotation.eulerAngles;
        //Debug.DrawLine(mainCam.position, mainCam.forward + (mainCam.position + cameraRotation + new Vector3(20, 0 ,0)), Color.red);
    }

    void Shoot()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, Mathf.Infinity, playerLayer))
        {
            PlayerShoot playerShoot = hit.transform.GetComponentInChildren<PlayerShoot>();
            playerShoot.Hit(damage);
        }
    }

    public void Hit(int damageTaken)
    {
        health -= damageTaken;
        Debug.Log("Hit");

        if (health <= 0)
        {
            BroadcastMessage(nameof(Die));
        }
    }
    [SynchronizableMethod]
    void Die()
    {
        Debug.Log("PlayerDied");
    }
}

