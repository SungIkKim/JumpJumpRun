using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 4;

    public float timeBetSpawnMin = 0.5f;
    public float timeBetSpawnMax = 1.0f;
    private float timeBetSpawn;

    public float yMin = -3.5f;
    public float yMax = 1.5f;
    private float xPos = 20f;

    private GameObject[] platforms;
    private int currnetIndex = 0;

    private Vector2 poolPosition = new Vector2(0, 25);
    private float lastSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count];

        for(int i=0; i<count;i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameover)
        {
            return;
        }
        
        if(Time.time >= lastSpawnTime+timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            float yPos = Random.Range(yMin, yMax);

            platforms[currnetIndex].transform.position = new Vector2(xPos, yPos);
            currnetIndex++;

            if(currnetIndex>=count)
            {
                currnetIndex = 0;
            }
        }
    }
}
