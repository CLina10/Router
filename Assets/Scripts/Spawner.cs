using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject wavePrefab;
    [SerializeField]
    AI ai;

    void Start()
    {
        SpawnWave(wavePrefab);
    }

    void SpawnWave(GameObject wave)
    {
        int enemyCount = wavePrefab.transform.childCount;
        List<Vector3> enemyPositions = new List<Vector3>(enemyCount);

        foreach (Transform enemyPos in wavePrefab.transform)
        {
            enemyPositions.Add(enemyPos.position);
        }

        ai.Spawn(enemyPositions);
    }
}