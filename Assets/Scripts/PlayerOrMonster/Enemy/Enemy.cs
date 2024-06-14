using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    protected Animator anim;
    protected PhysicsCheck physicsCheck;
    [Header("基本速度")]
    public float normalSpeed;
    public float chaseSpeed;

    public float currentSpeed;
    public Vector3 faceDir;


    [Header("计时器")]
    public float waitTime;
    public float waitTimeCounter;
    public bool wait;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = normalSpeed;
        physicsCheck = GetComponent<PhysicsCheck>();
        waitTimeCounter = waitTime;
    }

    private void Update()
    {
        faceDir = new Vector3(-transform.localScale.x, 0, 0);
        if (physicsCheck.touchDir)
        {
            physicsCheck.touchDirOffect.x = -physicsCheck.touchDirOffect.x;
            wait = true;
        }
        TimeCounter();

    }

    private void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        if(!isHurt & !isDead)
            rb.velocity = new Vector2(currentSpeed * faceDir.x * Time.deltaTime, rb.velocity.y);

    }
    public void TimeCounter()
    {

        if (wait)
        {
            waitTimeCounter -= Time.deltaTime;
            if( waitTimeCounter <= 0)
            {
                wait = false;
                waitTimeCounter = waitTime;
                transform.localScale = new Vector3(faceDir.x, 1, 1);
            }
        }

    }
    public Transform attacker;
    public bool isHurt;
    public float hurtForce;
    public void OnTakeDamage(Transform attackTrans)
    {
        attacker = attackTrans;

        if (attackTrans.position.x - transform.position.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if(attackTrans.position.x - transform.position.x < 0)
            transform.localScale = new Vector3(1, 1, 1);
        isHurt = true;
        anim.SetTrigger("hurt");
        Vector2 dir = new Vector2(transform.position.x - attackTrans.position.x, 0).normalized;
        StartCoroutine(OnHurt(dir));

    }

    IEnumerator OnHurt(Vector2 dir)
    {
        rb.AddForce(dir * hurtForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }

    public void OnDie()
    {
        gameObject.layer = 2;
        anim.SetBool("dead", true);
        isDead = true;
    }

    public bool isDead;
    private void DestroyAfterAnimation()
    {
        Destroy(this.gameObject);
    }



}
