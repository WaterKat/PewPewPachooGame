using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWaves : MonoBehaviour
{
    public GameObject player;

    public List<GameObject> enemies;

    public float spawnDistance = 30f;

    public float spawnAngle = 90f;

    private float timeElapsed;

    private float timeBetweenWaves = 15;
    private float lastWave = 0;

    private void Update()
    {

        timeElapsed += Time.deltaTime;

        if (Time.time - lastWave > timeBetweenWaves)
        {
            lastWave = Time.time;

            float startDegree = Random.Range(0, 360);
            int spawnNumber = Mathf.FloorToInt(timeElapsed / Random.Range(5f,8f));
            for (int i = 0; i < spawnNumber; i++)
            {
                GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Count)]);
                enemy.transform.position = player.transform.position + WavePosition(i / (float)spawnNumber, spawnAngle, startDegree) * spawnDistance;
            }
        }
    }

    public Vector3 WavePosition(float delta, float width, float startDegree) //in degrees
    {
        float degree = Mathf.Lerp(0, width, delta) + startDegree;
        Quaternion rotation = Quaternion.Euler(0, 0, degree);
        return rotation * Vector3.right;
    }
}



