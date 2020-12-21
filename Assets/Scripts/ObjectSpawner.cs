using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //Spawn random number of objects at random, previously determined locations
    //https://www.youtube.com/watch?v=iLTP4EbM1N4

    public Transform[] SpawnPoints;
    public float SpawnTime = 2.0f;
    public float RepeatRate = 2.0f;


    public GameObject ObjectToSpawn;
    //public GameObject[] ObjectToSpawn; - use for more objects

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", SpawnTime, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        //set the number of spawned items randomly
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(ObjectToSpawn, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
    }
}
