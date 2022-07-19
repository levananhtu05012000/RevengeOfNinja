using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour
{
    private float health;
    private Animator animationController;

    private IEnumerator coroutinAttack;
    [SerializeField]
    private GameObject prefabFireball;
    private bool hasDetectPlayer = false;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;


    private void Awake()
    {
        health = gameObject.GetComponent<HealthBarBehaviour>().maxHealth;
        coroutinAttack = Attack();
    }
    private void Start()
    {
        animationController = GetComponent<Animator>();
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

    private void CheckHealthDown()
    {
        float currentHealth = gameObject.GetComponent<HealthBarBehaviour>().CurrHealth;

        if (currentHealth < health)
        {
            animationController.SetTrigger(Constants.SkeletonTriggerTakeHit);
            health = currentHealth;
        }
        if (currentHealth < 0)
        {
            animationController.SetTrigger(Constants.SkeletonTriggerDeath);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Flip(bool isRight)
    {
        Vector3 theScale = transform.localScale;
        theScale.x = isRight ? -1 : 1;
        transform.localScale = theScale;
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => hasDetectPlayer);
            animationController.SetTrigger(Constants.SkeletonTriggerAttack);
            yield return new WaitUntil(() => animationController.GetCurrentAnimatorStateInfo(0).IsName(Constants.SkeletonTriggerAttack));
            Vector2 firePosition = transform.position;
            Instantiate<GameObject>(prefabFireball, firePosition, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
