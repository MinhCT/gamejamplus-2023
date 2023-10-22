using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : BaseStatus
{
    override public void Die() {
        base.Die();
        Debug.Log("Player Die");
    }
}
