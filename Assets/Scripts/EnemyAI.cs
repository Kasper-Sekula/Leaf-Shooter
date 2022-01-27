using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 20f;
    [SerializeField] float enemyDamage = 20f;
    
    float distanceToPlayer = Mathf.Infinity;
    bool ifDamageRecently = false;
    NavMeshAgent navMeshAgent;
    Transform target;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void CallEnemyAI()
    {
        EngagePlayer();
    }

    public void FindPlayer()
    {
        //print(target.transform.name);
    }

    private void EngagePlayer()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToPlayer <= chaseRange)
        {
            if (distanceToPlayer <= navMeshAgent.stoppingDistance +1f)
            {
                PlayerHealth playerHealth =  target.GetComponent<PlayerHealth>();
                if (playerHealth == null) { return; }

                if (!ifDamageRecently)
                {
                    target.GetComponent<PlayerHealth>().DealDamage(enemyDamage);
                    StartCoroutine(AttackPlayer());
                }
            }

            if (distanceToPlayer >= navMeshAgent.stoppingDistance)
            {
                ChasePlayer();
            }
        }
    }
    private IEnumerator AttackPlayer()
    {
        ifDamageRecently = true;
        yield return new WaitForSeconds(2);
        ifDamageRecently = false;
    }

    private void ChasePlayer()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
}
