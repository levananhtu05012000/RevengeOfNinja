using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private int jumpCount = 0;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 5f;


    //[SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX != 0)
        {
            //anim.SetBool("isMoving", true);
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x = dirX;
            gameObject.transform.localScale = newScale;
        }
        else
        {
            //anim.SetBool("isMoving", false);
        }

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (IsGrounded())
        {
            jumpCount = 2;
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            //jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("attack");

            if (Random.Range(0, 100) > 50)
                anim.SetFloat("attackState", 1);
            else
                anim.SetFloat("attackState", 2);
        }

        anim.SetFloat("moveX", Mathf.Abs(rb.velocity.x) != 0 ? 1 : 0.08f);
        anim.SetFloat("moveY", rb.velocity.y > 1 ? 1 : (rb.velocity.y < -1 ? -1 : 0));

        //UpdateAnimationState();
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = transform.position;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}