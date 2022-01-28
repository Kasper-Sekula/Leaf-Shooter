using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 20f;
    [SerializeField] float enemyDamage = 20f;
    [SerializeField] AudioSource audioSource;
    
    float distanceToPlayer = Mathf.Infinity;
    float distanceToTree = Mathf.Infinity;
    float treeChaseRange = 200f;
    bool ifDamageRecently = false;
    bool ifTreeDamageRecently = false;
    NavMeshAgent navMeshAgent;
    Transform target;
    Transform treeTarget;


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
        target = GameObject.FindGameObjectWithTag("Player").transform;
        treeTarget = GameObject.FindGameObjectWithTag("Tree").transform;
    }

    public void CallEnemyAI()
    {
        EngagePlayer();
        //EngageTree();
    }

    public void FindPlayer()
    {
        //print(target.transform.name);
    }

    private void EngagePlayer()
    {
        if (target == null) { return; }
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
                    PlayPunchSound();
                    StartCoroutine(AttackPlayer());
                }
            }
        //     else
        //     {
        //     PlayerHealth playerHealth =  treeTarget.GetComponent<PlayerHealth>();
        //         if (playerHealth == null) { return; }

        //         if (!ifDamageRecently)
        //         {
        //             treeTarget.GetComponent<PlayerHealth>().DealDamage(enemyDamage);
        //             PlayPunchSound();
        //             StartCoroutine(AttackPlayer());
        //         }
        // }

            if (distanceToPlayer >= navMeshAgent.stoppingDistance)
            {
                ChasePlayer(target);
            }
        }

        if (distanceToPlayer >= chaseRange)
        {
            EngageTree();
        }

    }

    private void EngageTree()
    {
        if (treeTarget == null) { return; }
        distanceToTree = Vector3.Distance(transform.position, treeTarget.transform.position);

        if (distanceToTree < treeChaseRange)
        {
            if (distanceToTree <= navMeshAgent.stoppingDistance +1f)
            {
                PlayerHealth treeHealt =  treeTarget.GetComponent<PlayerHealth>();
                if (treeHealt == null) { return; }
                print("one better tree");
                if (!ifTreeDamageRecently)
                {
                    treeTarget.GetComponent<PlayerHealth>().DealDamage(enemyDamage);
                    PlayPunchSound();
                    StartCoroutine(AttackTree());
                }
            }

            if (distanceToTree >= navMeshAgent.stoppingDistance)
            {
                ChasePlayer(treeTarget);
            }
        }
    }

    private IEnumerator AttackPlayer()
    {
        ifDamageRecently = true;
        yield return new WaitForSeconds(2);
        ifDamageRecently = false;
    }

    private IEnumerator AttackTree()
    {
        ifTreeDamageRecently = true;
        yield return new WaitForSeconds(2);
        ifTreeDamageRecently = false;
    }


    private void ChasePlayer(Transform target)
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);    
    }

    private void PlayPunchSound()
    {
        audioSource.Play();
    }
}
