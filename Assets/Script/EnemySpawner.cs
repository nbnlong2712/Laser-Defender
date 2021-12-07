using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweetWave = 2.5f;
    [SerializeField] WaveConfigSO waveConfig;
    [SerializeField] bool isLooping;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return waveConfig;
    }

    IEnumerator SpawnEnemy()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                waveConfig = wave;
                for (int i = 0; i < waveConfig.GetEnemyCount(); i++)
                {
                    Instantiate(waveConfig.GetEnemyPrefabs(i),
                        waveConfig.GetStartingWayPoint().position,
                        Quaternion.identity,
                        transform);
                    yield return new WaitForSeconds(waveConfig.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweetWave);
            }
        }
        while (isLooping);
    }
}