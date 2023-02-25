using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public Animator PlayerAni;
    bool isDead = false;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAni = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDame(float EnemyDamage)
    {
        CurrentHealth -= EnemyDamage;
        if (CurrentHealth <= 0)
        {
            playerController.GetComponent<PlayerController>().movespeed = 0f;
            isDead = true;
            PlayerAni.SetBool("isDead", isDead);
        }
    }
}
