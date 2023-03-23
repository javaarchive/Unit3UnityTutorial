using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    public GameObject[] obstacles;

    public Vector3 spawnPosition = new Vector3(-57, 0, 250);

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacle", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle(){
        GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Length)];
        float randomizedTime = Random.Range(3.5f, 6.5f);
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        Invoke("SpawnObstacle", randomizedTime);
    }
}
