using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("…À∫¶")]
    public int damage;
    [Header("…À∫¶∑∂Œß")]
    public float attackRange;
    [Header("…À∫¶∆µ¬ ")]
    public float attackRate;




    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Character>().TakeDamage(this);
    }


}
