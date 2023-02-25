using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.InputSystem; // use this for new input system
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // khoi tao thuoc tinh
    public float movespeed;
    Rigidbody2D PlayerRB;
    Animator PlayerAnimator;
    Vector2 MoveDirection = Vector2.zero;
    public InputAction Player;
    bool CanMove = true;
    public GameObject SwordHitBox;
    Collider2D PlayerSwordHB;
    public static PlayerController instance;
    public string StorageArea;
    public float KnockBackStrength = 15f;
    float PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerSwordHB = SwordHitBox.GetComponent<Collider2D>();
        PlayerHealth = GetComponent<PlayerHealth>().CurrentHealth;
        movespeed = 10f;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        MoveDirection = Player.ReadValue<Vector2>();        
    }
    private void FixedUpdate()
    {
        PlayerRB.velocity = new Vector2(MoveDirection.x * movespeed, MoveDirection.y * movespeed); 
        if (CanMove == true && MoveDirection != Vector2.zero) 
        {
            PlayerAnimator.SetBool("isMoving", true);
            PlayerAnimator.SetFloat("MoveX", MoveDirection.x); 
            PlayerAnimator.SetFloat("MoveY", MoveDirection.y); 
        }
        else
        {
            PlayerAnimator.SetBool("isMoving", false);
        }
    }
    void OnFire()
    {
        PlayerAnimator.SetTrigger("attack");
    }
    public void LockMovement()
    {
        CanMove = false;
        movespeed = 0f;
    }
    public void UnlockMovement()
    {
        movespeed = 10f;
        CanMove = true;
    }
    // necessary if you don't have it the input stystem won't work
    private void OnEnable()
    {
        Player.Enable();
    }
    private void OnDisable()
    {
        Player.Disable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindWithTag("enemy"))
        {
            /*Vector2 difference = (transform.position - collision.transform.position).normalized;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);*/
        }
    }
}
   