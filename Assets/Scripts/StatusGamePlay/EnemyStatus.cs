using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : BaseStatus
{
    override public void Die() {
        base.Die();
        Destroy(gameObject);
    }
}
