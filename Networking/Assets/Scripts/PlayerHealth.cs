using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alteruna;

public class PlayerHealth : AttributesSync
{
    [SynchronizableField] public float health = 100;

    private Alteruna.Avatar avatar;

    private void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>();
    }

    private void Start()
    {
        if (!avatar.IsMe)
            enabled = false;

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Player died");
            BroadcastRemoteMethod(nameof(Die));
        }
    }

    [SynchronizableMethod]
    void Die()
    {
        Destroy(gameObject);
    }
}




