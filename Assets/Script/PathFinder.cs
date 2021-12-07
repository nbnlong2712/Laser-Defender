using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waveList;
    int waveIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waveList = waveConfig.GetWayPoints();
        transform.position = waveList[waveIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waveIndex < waveList.Count)
        {
            Vector3 targetPos = waveList[waveIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if (transform.position == targetPos)
            {
                waveIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
