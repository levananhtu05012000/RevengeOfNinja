using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class FlyingEyeBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animationController;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    private bool hasDetectPlayer = false;

    private float moveSpeed = 1f;
    private bool isFlyUp = true;
    private float health;
    private Vector2 originalPosition;
    [SerializeField]
    private float movingDistance;
    private IEnumerator coroutinAttack;
    private void Awake()
    {
        health = gameObject.GetComponent<HealthBarBehaviour>().maxHealth;
        coroutinAttack = Attack();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animationController = GetComponent<Animator>();
        originalPosition = new Vector2(transform.position.x, transform.position.y);

        // first move of goblin
        Vector2 direction = new Vector2(0, 1);
        rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
        StartCoroutine(Moving());
        StartCoroutine(coroutinAttack);
    }
    private void Update()
    {
        CheckHealthDown();
        GameObject player = GameObject.FindGameObjectWithTag(Constants.TagPlayer);
        bool isRight = transform.position.x - player.transform.position.x >= 0;
        Flip(isRight);

        // detact player
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        hasDetectPlayer = colInfo != null;
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => hasDetectPlayer);
            GameObject.FindGameObjectWithTag(Constants.TagPlayer).GetComponent<HealthBarBehaviour>().TakeDamage(Constants.FlyingEyeDmg, false);
            yield return new WaitForSeconds(1);
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
            isFlyUp = !isFlyUp;
            yield return new WaitForSeconds(2);
            Vector2 direction = new Vector2(0, isFlyUp ? 1 : -1);
            rb2d.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    private void CheckHealthDown()
    {
        float currentHealth = gameObject.GetComponent<HealthBarBehaviour>().CurrHealth;

        if (currentHealth < health)
        {
            animationController.SetTrigger(Constants.FlyingEyeTriggerTakeHit);
            AudioManager.Play(AudioClipName.FleshTakehit);
            health = currentHealth;
        }
        if (currentHealth <= 0)
        {
            rb2d.velocity = Vector2.zero;
            animationController.SetTrigger(Constants.FlyingEyeTriggerDeath);
        }
    }
    private bool HasEndRoutin()
    {
        float maxDistanceAround = Mathf.Abs(transform.position.y - originalPosition.y);
        return (movingDistance / 2 - maxDistanceAround < 0);
        // add new velocity
    }
    void Flip(bool isRight)
    {
        Vector3 theScale = transform.localScale;
        theScale.x = isRight ? -1 : 1;
        transform.localScale = theScale;
    }


}
