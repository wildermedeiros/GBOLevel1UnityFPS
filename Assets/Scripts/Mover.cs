using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    Transform PlayerTransform;
    NavMeshAgent navMeshAgent;

    private void Awake() 
    {
        PlayerTransform = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = PlayerTransform.position; 
    }
}
