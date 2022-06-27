using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    private IEnumerator coroutinAttack;
    [SerializeField]
    private GameObject prefabFireball;
    private bool hasDetectPlayer = false;

    private void Awake()
    {
        coroutinAttack = Attack();
    }
    private void Start()
    {
        StartCoroutine(coroutinAttack);
    }
    private void Update()
    {

        GameObject player = GameObject.FindGameObjectWithTag(Constants.TagPlayer);
        bool isRight = transform.position.x - player.transform.position.x >= 0;
        Flip(isRight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TagPlayer))
        {
            hasDetectPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TagPlayer))
        {
            hasDetectPlayer = false;
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => hasDetectPlayer);
            Vector2 firePosition = transform.position;
            Instantiate<GameObject>(prefabFireball, firePosition, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
    void Flip(bool isRight)
    {
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x = isRight ? -1 : 1;
        transform.localScale = theScale;
    }
}
