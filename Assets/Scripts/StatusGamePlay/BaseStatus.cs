using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatus : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public void TakeDamage(float damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            currentHealth = 0;
            Die();
        }
    }
    public virtual void Die() {}
}
