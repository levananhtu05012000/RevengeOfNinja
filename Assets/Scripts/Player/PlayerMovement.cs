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

    private float moveSpeed = 3f;

    private float jumpForce = 5f;

    [HideInInspector]
    public bool isDashing = false;

    private bool isTouchControl = false;

    [SerializeField]
    private GameObject trailEffectPrefab;
    private float timeBtwTrailEffect = 0.02f;
    private float countdownTimeBtwTrailEffect = 0f;

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
        if (!isTouchControl) dirX = Input.GetAxisRaw("Horizontal");

        if (dirX != 0)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x = dirX;
            gameObject.transform.localScale = newScale;
        }

        if (IsGrounded())
        {
            jumpCount = 1;
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponent<HealthBarBehaviour>().TakeDamage(10, false);
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            anim.SetFloat("moveX", Mathf.Abs(rb.velocity.x) != 0 ? 1 : 0.08f);
            anim.SetFloat("moveY", rb.velocity.y > 1 ? 1 : (rb.velocity.y < -1 ? -1 : 0));
        }

        if (countdownTimeBtwTrailEffect <= 0)
        {
            countdownTimeBtwTrailEffect = timeBtwTrailEffect;
            if (isDashing)
            {
                GameObject trail = Instantiate(trailEffectPrefab, transform.position, Quaternion.identity);
                Destroy(trail, 3f);
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = dirX;
                trail.transform.localScale = newScale;
            }
        }
        else
        {
            countdownTimeBtwTrailEffect -= Time.fixedDeltaTime;
        }
    }

    public void BuuttonJumpClicked()
    {
        if (jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }
    }

    public void SetDirX(float value)
    {
        dirX = value;
        isTouchControl = value != 0;
    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            GetComponent<CheckpointController>().ChangeCheckpoint(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BuffHP"))
        {
            if (GetComponent<BuffController>().CollectBuffHP())
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Transform swordPoint = transform.Find("SwordPoint").transform;
        if (!swordPoint) return;
        Gizmos.DrawWireSphere(swordPoint.position, 0.33f);
    }

}