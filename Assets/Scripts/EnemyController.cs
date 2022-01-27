using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyAI enemyAI;

    public void GetEnemyAI()
    {
        enemyAI.CallEnemyAI();
    }
}
