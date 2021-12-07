using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config", fileName ="New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float timeBetweenEnemySpawn = 0.7f;
    [SerializeField] float spawnTimeVariance = 0.4f;
    [SerializeField] float minSpawnTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        //Get list child cua mot object nao do
        List<Transform> list = new List<Transform>();
        foreach(Transform trans in pathPrefab)
        {
            list.Add(trans);
        }
        return list;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index)
    {
       return enemyPrefabs[index];
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - spawnTimeVariance, timeBetweenEnemySpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}