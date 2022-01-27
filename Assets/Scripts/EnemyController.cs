using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyAI enemyAI;

    PlayerHealth playerHealth;

    public void GetEnemyAI()
    {
        enemyAI.CallEnemyAI();
    }
}
