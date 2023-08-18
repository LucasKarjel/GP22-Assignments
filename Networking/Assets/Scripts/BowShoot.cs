using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : MonoBehaviour
{
    float charge;

    public float chargeMax;
    public float chargeRate;
    public float baseDamage;
    public float damageDealt;

    public Transform spawn;
    public Rigidbody arrowObj;

    private void Update()
    {
        if (InputManager.Instance.PlayerShotThisFrame() && charge < chargeMax)
        {
            charge += Time.deltaTime * chargeRate;
            if (!InputManager.Instance.PlayerShotThisFrame())
            {
                damageDealt = charge * baseDamage;
                Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.identity) as Rigidbody;
                arrow.AddForce(spawn.forward * charge, ForceMode.Impulse);
                charge = 0;
            }
        }
    }

    //Pickup
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.SetParent(other.gameObject.transform);
        }
    }
}
