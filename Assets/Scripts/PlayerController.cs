using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform jumpCheck;
    [SerializeField] Transform suicideCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float playerSpeed = 10;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float jumpMultiplier = 2f;
    [SerializeField] float jumpVelocity = 2;
    public GameObject cam;
    private Rigidbody2D RB;
    private SpriteRenderer SR;
    private AudioSource ASR;
    private Animator Anim;
    private bool isGrounded;
    private bool isJumping;

    [SerializeField] AudioClip[] jump;

    void Start()
    {
        ASR = GetComponent<AudioSource>();
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapArea(groundCheck.position - new Vector3(0.4f, -0.1f, 0), groundCheck.position - new Vector3(-0.4f, 0, 0),groundLayer);
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 playerDir = new Vector2(x, y);

        if (playerDir.x!=0)
        {
            Anim.SetBool("isWalking", true);
        }
        else
        {
            Anim.SetBool("isWalking", false);
        }
        if (playerDir.x > 0)
        {
            SR.flipX = false;
        }
        else if (playerDir.x < 0)
        {
            SR.flipX = true;
        }

        Walk(playerDir);

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ASR.clip = jump[Random.Range(0, 2)];
        }

        Jump();
    }

    private void Walk(Vector2 dir)
    {
        RB.velocity = (new Vector2(dir.x * playerSpeed, RB.velocity.y));
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            ASR.Play();
            RB.velocity = Vector2.up * jumpVelocity;
        }

        if (RB.velocity.y < 0)
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //else if (RB.velocity.y > 0 && !Input.GetButton("Jump"))
        else if (RB.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            RB.velocity += Vector2.up * Physics2D.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
        }

        /*
        isJumping = true;
        RB.velocity = new Vector2(RB.velocity.x, 0);
        RB.velocity += Vector2.up * jumpForce;
        realTimer = interval;
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        //Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        Gizmos.DrawWireCube(groundCheck.position, new Vector3(0.8f, 0.05f));
    }
}