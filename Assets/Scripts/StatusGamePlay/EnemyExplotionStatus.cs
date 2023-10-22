using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplotionStatus : BaseStatus
{
    public GameObject explotion;

    override public void Die() {
        base.Die();
        Instantiate(explotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
