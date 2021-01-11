using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bomb;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;

    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBomb = (GameObject)Instantiate(bomb, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBomb.transform.localScale = Vector3.one * spawnSize;
            newBomb.transform.parent = transform;
        }
    }
}
