using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Character : MonoBehaviour
{
    [Header("���Ѫ��")]
    public float maxHP;
    [Header("��ǰѪ��")]
    public float currentHP;
    [Header("�����޵�ʱ��")]
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

    //�����޵�
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = transform;
            invulnerableCounter = invulnerableDuration;
        }

    }

}
