using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    private PhysicsCheck physicsCheck;
    private PlayerController playerController;
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        physicsCheck = this.GetComponent<PhysicsCheck>();
        playerController = this.GetComponent<PlayerController>();
    }

    private void Update()
    {
        SetAnimation();

    }

    public void SetAnimation()
    {
        animator.SetFloat("Walk", Mathf.Abs(rigidbody2D.velocity.x));
        animator.SetFloat("jumpY", rigidbody2D.velocity.y);
        animator.SetBool("isGround", physicsCheck.isGround);
        animator.SetBool("isDead", playerController.isDead);
        animator.SetBool("isAttk", playerController.isAttack);


    }

    public void PlayHurt()
    {
        animator.SetTrigger("hurt");
    }


    public void PlayerAttack()
    {
        animator.SetTrigger("attack");
    }
}
