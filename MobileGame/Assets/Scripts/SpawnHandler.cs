using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    float minDistance = -10f;
    float maxDistance = 10f;

    public GameObject player;
    public GameObject leftWallPrefab;
    public GameObject rightWallPrefab;
    public GameObject leftFlipperPrefab;
    public GameObject rightFlipperPrefab;
    private int spawnNumber = 1;
    private int spawnHeight = 4;

    // Start is called before the first frame update
    void Start()
    {
        float distanceBetweenObjects = Random.Range(minDistance, maxDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > spawnHeight)
        {
            SpawnWalls();
            spawnNumber++;
            spawnHeight *= spawnNumber;
        }
    }


    void SpawnWalls()
    {
        var spawnPosition = new Vector2(-3.05f, (20 * spawnNumber));

        // Instantiate the wall prefab

        GameObject leftWall = Instantiate(leftWallPrefab, spawnPosition, Quaternion.Euler(0,0,90));
        GameObject rightWall = Instantiate(rightWallPrefab, new Vector2((spawnPosition.x + 6.1f),spawnPosition.y), Quaternion.Euler(0, 0, 90));

        // Instantiate the flipper prefab
       
        float randomFlipperY = Random.Range(0, 10);
        Vector2 leftFlipperSpawnPosition = spawnPosition + new Vector2(randomFlipperY, 0f);
        Vector2 rightFlipperSpawnPosition = new Vector2(1.75f, randomFlipperY);
        for (int i = 0; i < 1; i++)
        {
            if (i == 0)
            {
                GameObject leftFlipper = Instantiate(leftFlipperPrefab, new Vector2(spawnPosition.x, leftFlipperSpawnPosition.y + spawnPosition.y), Quaternion.identity);
                GameObject rightFlipper = Instantiate(rightFlipperPrefab, new Vector2((spawnPosition.x + 6.1f), rightFlipperSpawnPosition.y + spawnPosition.y), Quaternion.identity);
            }
            else
            {
                GameObject leftFlipper = Instantiate(leftFlipperPrefab, new Vector2(spawnPosition.x, -leftFlipperSpawnPosition.y + spawnPosition.y), Quaternion.identity);
                GameObject rightFlipper = Instantiate(rightFlipperPrefab, new Vector2((spawnPosition.x + 6.1f), (-rightFlipperSpawnPosition.y + spawnPosition.y)), Quaternion.identity);
            }
        }
    }
}
