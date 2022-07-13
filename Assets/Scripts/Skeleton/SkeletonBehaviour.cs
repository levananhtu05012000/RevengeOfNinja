using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class SkeletonBehaviour : MonoBehaviour
{
    private float health;
    private Animator animationController;
    private void Awake()
    {
        health = gameObject.GetComponent<HealthBarBehaviour>().maxHealth;
    }
    private void Start()
    {
        animationController = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckHealthDown();

        GameObject player = GameObject.FindGameObjectWithTag(Constants.TagPlayer);
        bool isRight = transform.position.x - player.transform.position.x >= 0;
        Flip(isRight);
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
}
