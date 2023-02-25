using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class skeleton : MonoBehaviour
{
    float movespeed = 4f;
    Rigidbody2D STrb;
    Animator STani;
    Vector2 moveDirection = Vector2.zero;
    Transform target;
    public float skeletonHealth = 3f;
    float range;
    bool FacingRight;
    public PlayerHealth playerhealth;
    float dealDame = 10f;
    bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        STrb = GetComponent<Rigidbody2D>();
        STani = GetComponent<Animator>();
        target = GameObject.FindWithTag("player").transform;
    }
    public void TakeDameOfSkeleton(float damage)
    {
        skeletonHealth -= damage;
        STani.SetTrigger("GotHit");
        STani.SetBool("isAlive", true);
        StartCoroutine(DelayTime());
        if (skeletonHealth <= 0)
        {
            target = null;
            movespeed = 0f;
            STani.SetBool("isAlive", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.transform.position - this.transform.position).normalized;
            range = Vector2.Distance(target.transform.position, this.transform.position);
            moveDirection = direction;
            if (target.transform.position.x > gameObject.transform.position.x && FacingRight)
            {
                Flip();
            }
            else if (target.transform.position.x < gameObject.transform.position.x && !FacingRight)
            {
                Flip();
            }
        }
        
    }
    void FixedUpdate()
    {
        if (target)
        {
            if (range <= 7)
            {
                STani.SetBool("isMoving", true);
                STrb.velocity = new Vector2(moveDirection.x, moveDirection.y) * movespeed;
            }
            else
            {
                STani.SetBool("isMoving", false);
            }
        }
    }
    private void LateUpdate()
    {
        if (target)
        {
            if (range <= 1.5)
            {
                isAttack = true;
                STani.SetBool("Attack", isAttack);
            }
            else
            {
                isAttack = false;
                STani.SetBool("Attack", isAttack);
            }
        }
    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        this.gameObject.transform.localScale = tmpScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            playerhealth.TakeDame(dealDame);
        }
    }
    public IEnumerator DelayTime()
    {
        target = null;
        yield return new WaitForSeconds(.5f);
        target = GameObject.FindWithTag("player").transform;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
