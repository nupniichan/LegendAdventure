using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class slime : MonoBehaviour
{
    float movespeed = 4f;
    Rigidbody2D SlimeRB;
    Transform target;
    Vector2 moveDirection;
    Animator slimeAni;
    float damage = 10f;
    float range;
    [SerializeField] float SlimeHealth = 3f;
    bool isAlive = true;
    public PlayerHealth playerHealth;
    bool facingRight;
    private void Start()
    {
        SlimeRB = GetComponent<Rigidbody2D>();
        slimeAni = GetComponent<Animator>();
        target = GameObject.FindWithTag("player").transform;
    }
    private void Update()
    {
        // chase player
        if (target) // target == true
        {
            Vector3 Direction = (target.position - transform.position).normalized;
            range = Vector2.Distance(transform.position, target.position);
            moveDirection = Direction;
            if (target.transform.position.x > gameObject.transform.position.x && facingRight)
                Flip();
            if (target.transform.position.x < gameObject.transform.position.x && !facingRight)
                Flip();
        }
    }
    private void FixedUpdate()
    {
        // chase player
        if (target)
        {
            if (range <= 7)
            {
                slimeAni.SetBool("isMoving", true);
                SlimeRB.velocity = new Vector2(moveDirection.x, moveDirection.y) * movespeed;
            }
            else
            {
                slimeAni.SetBool("isMoving", false);
            }
        }
    }

    public void TakeDameOfSlime(float damage)
    {
        SlimeHealth -= damage;
        slimeAni.SetTrigger("gotHit");
        slimeAni.SetBool("isAlive", isAlive);
        StartCoroutine(DelayTime());
        if (SlimeHealth <= 0)
        {
            target = null;
            movespeed = 0f;
            isAlive = false;
            slimeAni.SetBool("isAlive", isAlive);
            StartCoroutine("DelayTime");
        }
    }

    public IEnumerator DelayTime()
    {
        target = null;
        yield return new WaitForSeconds(.5f);
        target = GameObject.FindWithTag("player").transform;  
    }
    private void OnCollisionEnter2D(Collision2D EnemyDamage)
    {
        if (EnemyDamage.gameObject.tag == "player")
        {
            playerHealth.TakeDame(damage);
        }
    }
    public void SlimeDeath()
    {
        Destroy(gameObject);
    }
    void Flip()
    {
        //here your flip funktion, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sword")
        {
            Vector2 difference = (transform.position - collision.transform.position).normalized;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }


}


