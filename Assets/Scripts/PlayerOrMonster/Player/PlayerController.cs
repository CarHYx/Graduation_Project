using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private PlayerAnimation playerAnimation;
    public PlayerInputController inputControl;
    private PhysicsCheck physicsCheck;

    [Header("基本参数")]
    public Vector2 inputDirection;
    public float speed;
    public float jumpForce;
    [Header("是否受伤")]
    public bool isHurt;
    public float hurtForce;
    [Header("是否死亡")]
    public bool isDead;

    [Header("是否攻击")]
    public bool isAttack;
    [Header("物理材质")]
    private CapsuleCollider2D coll;
    public PhysicsMaterial2D normal;
    public PhysicsMaterial2D wall;


    private void Awake()
    {
        inputControl = new PlayerInputController();
        rigidbody2D = this.GetComponent<Rigidbody2D>();
        inputControl.GamePlayer.Jump.started += Jump;
        physicsCheck = this.GetComponent<PhysicsCheck>();
        inputControl.GamePlayer.Attack.started += PlayerAttack;
        playerAnimation = this.GetComponent<PlayerAnimation>();
        coll = this.GetComponent<CapsuleCollider2D>();
    }



    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();

    }



    private void Update()
    {
        inputDirection = inputControl.GamePlayer.Movement.ReadValue<Vector2>();
        CheckStart();
    }

    private void FixedUpdate()
    {
        if(!isHurt && !isAttack)
            Move();
    }
    public void Move()
    {
        rigidbody2D.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime, rigidbody2D.velocity.y);
        int faceDir = (int)this.transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x < 0)
            faceDir = -1;
        //人物翻转
        this.transform.localScale = new Vector3(faceDir, 1, 1);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if(physicsCheck.isGround)
        {
            rigidbody2D.AddForce(this.transform.up * jumpForce, ForceMode2D.Impulse);
        }

       

    }

    private void PlayerAttack(InputAction.CallbackContext context)
    {
        if (!physicsCheck.isGround)
            return;
        playerAnimation.PlayerAttack();
        isAttack = true;
    }


    public void GetHurt(Transform attack)
    {
        isHurt = true;
        rigidbody2D.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attack.position.x), 0).normalized;
        rigidbody2D.AddForce(dir * hurtForce, ForceMode2D.Impulse);
    }

    public void PlayerDead()
    {
        isDead = true;
        inputControl.GamePlayer.Disable();


    }


    private void CheckStart()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }

}
