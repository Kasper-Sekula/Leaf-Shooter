using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 20f;
    
    float distanceToPlayer = Mathf.Infinity;
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
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }
}
