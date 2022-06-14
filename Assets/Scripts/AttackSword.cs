using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AttackSword : Skill
{
    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
        Animator anim = parent.GetComponent<Animator>();

        anim.SetTrigger("attack");

        if (Random.Range(0, 100) > 50)
            anim.SetFloat("attackState", 1);
        else
            anim.SetFloat("attackState", 2);

    }
    public override void BeginCooldown(GameObject parent)
    {

    }
}
