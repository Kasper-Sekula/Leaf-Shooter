using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] List<Transform> enemyAIs;
    [SerializeField] GameObject enemyPrefab;

    int numberOfEnemies = 0;
    int currentEnemies = 0;
    PlayerHealth playerHealth;
    List<Transform> numberOfActiveEnemies = new List<Transform>();

    public void GetEnemyAI()
    {
        numberOfActiveEnemies.Clear();
        foreach (Transform child in transform)
        {
            child.GetComponent<EnemyAI>().CallEnemyAI();
            numberOfActiveEnemies.Add(child);
        }
    }

    public void SpawningEnemies()
    {
        //print(numberOfActiveEnemies.Count);
        if (numberOfActiveEnemies.Count < 10)
        {
            SpawnEnemy();
            numberOfEnemies++;
        }
    }

    void SpawnEnemy()
    {
            int xPos = UnityEngine.Random.Range(-50,50);
            int zPos = UnityEngine.Random.Range(-50,50);
            //enemyPrefab.AddComponent

            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3( xPos, 1f, zPos), Quaternion.identity);
            newEnemy.transform.parent = transform;
            //enemyAIs.Add(newEnemy.GetComponent<EnemyAI>());
    }
}
