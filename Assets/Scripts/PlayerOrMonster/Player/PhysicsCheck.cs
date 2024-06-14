using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{


    public float checkRaduis;
    public LayerMask groundLayer;
    [Header("ÌøÔ¾×´Ì¬")]
    public bool isGround;
    public Vector2 bottomOffect;



    //×óÓÒÇ½Ìå
    public bool touchDir;
    //×óÓÒÆ«ÒÆÎ»ÖÃ
    public Vector2 touchDirOffect;



    private void Update()
    {
        Check();
    }

    private void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffect, checkRaduis, groundLayer);
        touchDir = Physics2D.OverlapCircle((Vector2)transform.position + touchDirOffect, checkRaduis, groundLayer);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffect, checkRaduis);

        Gizmos.DrawWireSphere((Vector2)transform.position + touchDirOffect, checkRaduis);
    }





}
