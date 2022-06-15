using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemis;

    public float timeSpawn;
    public float repeatSpawnRate;

    public Transform xRangeLeft;
    public Transform xRangeRight;

    public Transform yRangeUp;
    public Transform yRangeDown;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

        GameObject enemie = Instantiate(enemis[Random.Range(0, enemis.Length)], spawnPosition,gameObject.transform.rotation);
    }
}
