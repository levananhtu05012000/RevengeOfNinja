using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class GoblinBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animationController;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    private float moveSpeed = 1f;
    private bool facingRight = true;
    private Vector2 originalPosition;
    [SerializeField]
    private float movingDistance;
    private float health;
    private bool hasDetectPlayer = false;
    private bool isAttacking = false;
    private IEnumerator coroutinAttack;

    private void Awake()
    {
        health = gameObject.GetComponent<HealthBarBehaviour>().CurrHealth;
        //gameObject.GetComponent<HealthBarBehaviour>().CurrHealth = health;
        coroutinAttack = TriggerAttack();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animationController = GetComponent<Animator>();
        originalPosition = new Vector2(transform.position.x, transform.position.y);

        // first move of goblin
        Vector2 direction = new Vector2(1, 0);
        rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
        StartCoroutine(Moving());
        StartCoroutine(coroutinAttack);
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            GameObject.FindGameObjectWithTag(Constants.TagPlayer).GetComponent<HealthBarBehaviour>().TakeDamage(Constants.GoblinDmg, false);
        }
    }
    IEnumerator TriggerAttack()
    {
        while (true)
        {
            yield return new WaitUntil(() => hasDetectPlayer);
            animationController.SetTrigger(Constants.GoblinTriggerAttack);
            yield return new WaitForSeconds(2);
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

IEnumerator Moving()
    {
        while (true)
        {
            yield return new WaitUntil(HasEndRoutin);
            rb2d.velocity = Vector2.zero;
            yield return new WaitForSeconds(2);
            Flip();
            // add new velocity
            Vector2 direction = new Vector2(facingRight ? 1 : -1, 0);
            rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
        }
    }

    private bool HasEndRoutin()
    {
        float maxDistanceAround = Mathf.Abs(transform.position.x - originalPosition.x);
        return (movingDistance / 2 - maxDistanceAround < 0) || rb2d.velocity == Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealth = gameObject.GetComponent<HealthBarBehaviour>().CurrHealth;
        if (currentHealth < health)
        {
            rb2d.velocity = Vector2.zero;
            animationController.SetTrigger(Constants.GoblinTriggerTakeHit);
            health = currentHealth;
        }
        if(currentHealth < 0)
        {
            animationController.SetTrigger(Constants.GoblinTriggerDie);
        }

        // detact player
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            rb2d.velocity = Vector2.zero;
            hasDetectPlayer = true;
        } else
        {
            hasDetectPlayer = false;
        }
        animationController.SetBool("moving", rb2d.velocity.sqrMagnitude >= 0.2);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
