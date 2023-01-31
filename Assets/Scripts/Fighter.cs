using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fighter : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float attackRange = 10f;

    Transform PlayerTransform;
    NavMeshAgent navMeshAgent;

    private void Awake() 
    {
        PlayerTransform = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        var distanceToPlayer = Vector3.Distance(PlayerTransform.position, transform.position);
        if(distanceToPlayer < navMeshAgent.stoppingDistance)
        {   
            navMeshAgent.isStopped = true;
            AttackTarget();
        }
        else
        {
            navMeshAgent.isStopped = false;
        }        
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetTrigger("attack");              
    }

    public void HitEvent()
    {
        CastDamageCollider();
    }

    private void CastDamageCollider()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, attackRange, Vector3.up, 0);
        foreach (RaycastHit hit in hits)
        {
            Health playerHealth = hit.transform.GetComponent<Health>();
            if (playerHealth == null) { continue; }

            playerHealth.TakeDamage(damage);
        }
    }
}
