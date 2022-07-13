using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using UnityEngine;

public class GoblinAttack : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        rb2d = gameObject.GetComponentInParent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TagPlayer))
        {
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger(Constants.GoblinTriggerAttack);
        }
    }

}
