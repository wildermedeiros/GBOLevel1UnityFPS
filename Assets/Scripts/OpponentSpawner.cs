using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentSpawner : MonoBehaviour
{
    [SerializeField] GameObject oponnentPrefab = null;
    [SerializeField] float maxRandomRange = 5f;
    [SerializeField] float minRandomRange = 2f;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] Transform parentToSpawn = null;
    //[SerializeField] GameObject spawnEffect = null;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
    }

    private void Spawn()
    {
        var randomPosition = Random.insideUnitSphere * maxRandomRange;
        if (randomPosition.sqrMagnitude < minRandomRange) { return; }
        randomPosition.y = Mathf.Clamp(randomPosition.y, 1.4f, 1.5f);

        //var effect = Instantiate(spawnEffect, randomPosition, Quaternion.identity);
        var circle = Instantiate(oponnentPrefab, randomPosition, Quaternion.identity);
        circle.transform.SetParent(parentToSpawn);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, maxRandomRange);
        Gizmos.DrawWireSphere(transform.position, minRandomRange);
    }
}
