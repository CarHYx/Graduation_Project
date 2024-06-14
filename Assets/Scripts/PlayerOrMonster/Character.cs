using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Character : MonoBehaviour
{
    [Header("最大血量")]
    public float maxHP;
    [Header("当前血量")]
    public float currentHP;
    [Header("受伤无敌时间")]
    public float invulnerableDuration;
    private float invulnerableCounter;
    public bool invulnerable;

    public UnityEvent<Transform> OnTakeDamage;

    public UnityEvent OnTakeDead;

    private void Start()
    {
        currentHP = maxHP;

    }
    private void Update()
    {
        if(invulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
                invulnerable = false;
        }
    }
    public void TakeDamage(Attack attack)
    {
        if (invulnerable)
            return;
        if(currentHP - attack.damage > 0)
        {
            currentHP -= attack.damage;
            TriggerInvulnerable();
            OnTakeDamage?.Invoke(attack.transform);
        }
        else
        {
            currentHP = 0;
            OnTakeDead?.Invoke();
        }

    }

    //触发无敌
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = transform;
            invulnerableCounter = invulnerableDuration;
        }

    }

}
