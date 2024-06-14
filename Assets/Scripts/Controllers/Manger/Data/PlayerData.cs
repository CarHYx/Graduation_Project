using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class PlayerData
{

    public float atk;       //攻击
    public float def;       //防御
    public int hp;          //血量
    public float jumpForce; //跳跃高度
    public bool isDead;     //是否死亡
    public bool hurt;       //是否受伤
    public float atkIntervals;      //攻击间隔时间
    public float hurtIntervals;     //受伤间隔时间


}
