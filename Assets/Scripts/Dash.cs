using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dash : Skill
{
    public float dashSpeed;

    public override void Activate(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
        movement.isDashing = true;
        rigidbody.velocity = new Vector2(parent.transform.localScale.x * dashSpeed, 0f);

        rigidbody.gravityScale = 0f;
    }
    public override void BeginCooldown(GameObject parent)
    {
        PlayerMovement movement = parent.GetComponent<PlayerMovement>();
        Rigidbody2D rigidbody = parent.GetComponent<Rigidbody2D>();
        movement.isDashing = false;
        rigidbody.gravityScale = 2f;
    }
}
