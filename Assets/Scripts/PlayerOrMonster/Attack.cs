using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("�˺�")]
    public int damage;
    [Header("�˺���Χ")]
    public float attackRange;
    [Header("�˺�Ƶ��")]
    public float attackRate;




    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Character>().TakeDamage(this);
    }


}
