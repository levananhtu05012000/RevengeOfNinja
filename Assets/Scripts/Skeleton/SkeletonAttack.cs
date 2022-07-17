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
    private Animator animationController;

    private void Awake()
    {
        coroutinAttack = Attack();
    }
    private void Start()
    {
        animationController = gameObject.GetComponentInParent<Animator>();
        StartCoroutine(coroutinAttack);
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
            animationController.SetTrigger(Constants.SkeletonTriggerAttack);
            yield return new WaitUntil(() => animationController.GetCurrentAnimatorStateInfo(0).IsName(Constants.SkeletonTriggerAttack));
            Vector2 firePosition = transform.position;
            Instantiate<GameObject>(prefabFireball, firePosition, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
