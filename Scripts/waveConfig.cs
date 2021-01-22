using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class waveConfig : ScriptableObject
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandomFactor = .2f;
    [SerializeField] int numberOfObstaclesSpawned = 5;
    [SerializeField] float moveSpeed = 3f;

    private void Update()
    {
        if(ScoreManager.hits % 50 == 0)
        {
            moveSpeed++;
        }
    }

    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstaclesSpawned()
    {
        return numberOfObstaclesSpawned;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
