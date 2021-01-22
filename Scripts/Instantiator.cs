using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] List<waveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;
    
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping == true);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int index = startingWave; index < waveConfigs.Count; index++)
        {
            var currentWave = waveConfigs[index];
            yield return StartCoroutine(SpawnAllObstaclesinWaveRoutine(currentWave));
        }
    }
    
    private IEnumerator SpawnAllObstaclesinWaveRoutine(waveConfig particularWaveConfig)
    {
        for (int i = 0; i < particularWaveConfig.GetNumberOfObstaclesSpawned(); i++)
        {
            var newObstacle = Instantiate(
                particularWaveConfig.GetObstaclePrefab(),
                particularWaveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newObstacle.GetComponent<obstaclePath>().SetWaveConfig(particularWaveConfig);
            yield return new WaitForSeconds(particularWaveConfig.GetTimeBetweenSpawns());
        }
    }
}
