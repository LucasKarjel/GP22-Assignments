using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperManagement : MonoBehaviour
{
    public Transform player; // Reference to the player (ball)
    public GameObject[] allFlippers; // Array of all flipper GameObjects
    public int numClosestFlippers = 6; // Number of closest flippers to activate

    private List<KeyValuePair<float, GameObject>> flipperDistances = new List<KeyValuePair<float, GameObject>>();

    void Start()
    {
        // Populate the list with flipper distances
        foreach (GameObject flipper in allFlippers)
        {
            float distance = Vector3.Distance(player.position, flipper.transform.position);
            flipperDistances.Add(new KeyValuePair<float, GameObject>(distance, flipper));
        }

        // Sort the list by distance
        flipperDistances.Sort((a, b) => a.Key.CompareTo(b.Key));
    }

    void Update()
    {
        foreach (GameObject flipper in allFlippers)
        {
            // Update flipper position here
            flipper.transform.position = (flipper.transform.position);
        }
        // Activate the closest flippers and deactivate the rest
        for (int i = 0; i < allFlippers.Length; i++)
        {
            if (i < numClosestFlippers)
            {
                flipperDistances[i].Value.SetActive(true);
            }
            else
            {
                flipperDistances[i].Value.SetActive(false);
            }
        }
    }
}

