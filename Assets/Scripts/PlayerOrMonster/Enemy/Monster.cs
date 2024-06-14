using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Enemy
{
    public override void Move()
    {
        base.Move();
        anim.SetBool("walk", !wait);
    }
}
