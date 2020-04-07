using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectParcelGameManager : MonoBehaviour
{
    public EnemySpawnPoint[] the_Enemy_Spawn_Point;
    public float enemy_Spawn_Rate;
    private void Start()
    {
        the_Enemy_Spawn_Point = FindObjectsOfType<EnemySpawnPoint>();
        InvokeRepeating("CallSpawnEnemy", 5, enemy_Spawn_Rate);
    }

    void CallSpawnEnemy()
    {
        int i = Random.Range(0, the_Enemy_Spawn_Point.Length - 1);

        the_Enemy_Spawn_Point[i].SpawnEnemy();
    }
}
