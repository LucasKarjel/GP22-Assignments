using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage;
    BowShoot bowScript;

    private void Start()
    {
        bowScript = GameObject.Find("Bow").GetComponent<BowShoot>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<PlayerHealth>())
        {
            PlayerHealth health = col.GetComponent<PlayerHealth>();
            health.TakeDamage(bowScript.damageDealt);
        }
    }
}
