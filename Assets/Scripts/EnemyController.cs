using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyAI[] enemyAIs;

    PlayerHealth playerHealth;

    public void GetEnemyAI()
    {
        if (enemyAIs[0] == null) {return; }
        foreach (EnemyAI enemy in enemyAIs)
        {
            enemy.CallEnemyAI();
        }
    }
}
