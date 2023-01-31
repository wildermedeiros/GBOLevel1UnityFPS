using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] UnityEvent onHit;

    float healthPoints = 100f; 
    bool isDead = false;

    public void TakeDamage(float damage)
    {
        if (isDead) { return; }
        
        healthPoints -= damage;
        onHit.Invoke();
        
        if(Mathf.Approximately(healthPoints, 0))
        {
            isDead = true;
            ResetScene();
        }
        
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
