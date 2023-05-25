using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 11f;

    private float movementX;

    private SpriteRenderer spriteRender;
    private Rigidbody2D rigigBody2D;
    private Animator animator;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";

    private bool isGrounded;

    void Awake()
    {
        rigigBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerAnimator();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX * moveForce * Time.deltaTime, 0f, 0f);
    }

    private void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rigigBody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) isGrounded = true;
    }

    private void PlayerAnimator()
    {
        if (movementX > 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRender.flipX = false;
        }

        if (movementX < 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRender.flipX = true;
        }

        if (movementX == 0) animator.SetBool(WALK_ANIMATION, false);
    }
}
