using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public Collider2D Sword;
    float DamePerHit = 1f;
    float KnockBackStrength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Sword.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D EnemyTag)
    {
        // tim tag 
        if (EnemyTag.tag == "enemy")
        {
            slime SlimeEnemy = EnemyTag.GetComponent<slime>();
            if (SlimeEnemy != null) // neu co enemy thi deal dame
            {
                SlimeEnemy.GetComponent<slime>().TakeDameOfSlime(DamePerHit);
            }
            skeleton SkeletonEnemy = EnemyTag.GetComponent<skeleton>();
            if (SkeletonEnemy != null)
            {
                SkeletonEnemy.GetComponent<skeleton>().TakeDameOfSkeleton(DamePerHit);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Rigidbody2D enemyRB = gameObject.GetComponent<Rigidbody2D>();
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            enemyRB.AddForce(knockbackDirection * KnockBackStrength * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
