using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class FlyingEyeAttack : MonoBehaviour
{
    private IEnumerator coroutinAttack;
    private bool hasDetectPlayer = false;

    private void Awake()
    {
        coroutinAttack = Attack();
    }
    private void Start()
    {
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
            GameObject.FindGameObjectWithTag(Constants.TagPlayer).GetComponent<HealthBarBehaviour>().TakeDamage(10, false);
            yield return new WaitForSeconds(1);
        }
    }
}
