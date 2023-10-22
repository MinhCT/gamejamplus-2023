using System.Collections;
using System.Collections.Generic;
using UI.Screens;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : BaseStatus
{
    public UnityEvent eventDied;
    public InGameScreen inGameScreen;
    public override void TakeDamage(float damage) {
        base.TakeDamage(damage);
        inGameScreen.SetProgress(base.currentHealth / base.maxHealth);
    }
    override public void Die() {
        base.Die();
        eventDied.Invoke();
    }
}
