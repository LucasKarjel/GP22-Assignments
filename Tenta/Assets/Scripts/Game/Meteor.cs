using UnityEngine;

public class Meteor : MonoBehaviour
{
	public float speed = 1;
    public GameObject split;
    public GameObject Hit;
	public GameObject Explosion;

    void Start()
    {
		//Set a start speed
		GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		//bullet hit the asteroid
		if (other.gameObject.CompareTag("Bullet"))
		{
			//Spawn hit effect
			Vector3 hitPoint = (other.transform.position + transform.position) / 2;
			var newHit = Instantiate(Hit, hitPoint, Quaternion.identity);
			Destroy(newHit, 0.5f);

			//Remove bullet
			Destroy(other.gameObject);


			//Asteroid was destroyed

			//Spawn new asteroids
			if (split != null)
			{
				Instantiate(split, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 30));
				Instantiate(split, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 30));
			}

			//Spawn explostion effect
			var newExplosion= Instantiate(Explosion, transform.position, Quaternion.identity);
			Destroy(newExplosion, 0.5f);

			//Destroy asteroid
			Destroy(gameObject);
		}
	}
}
