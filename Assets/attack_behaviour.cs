using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_behaviour : StateMachineBehaviour
{

    private float _attackRange;
    private Vector2 target;
    Transform player;
    Rigidbody2D rb;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _attackRange = animator.GetBehaviour<Boss_Run>().attackRange;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        target = new Vector2(player.position.x, rb.position.y);
        boss.LookAtPlayer();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position, rb.position) <= _attackRange)
        {
            animator.SetTrigger("Idle1");
        }
        else
        {
            animator.SetTrigger("Approach1");
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
