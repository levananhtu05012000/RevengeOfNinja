using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_attack : StateMachineBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private Transform player;
    //private float timer;
    //public float minTime;
    //public float maxTime;
    private Vector2 target;
    private Vector2 newPos;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        //timer = Random.Range(minTime, maxTime);
        boss = animator.GetComponent<Boss>();
        target = new Vector2(player.position.x, rb.position.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (timer <= 0)
        //{
        //    animator.SetTrigger("Idle");
        //}
        //else
        //{
        //    timer -= Time.deltaTime;
        boss.LookAtPlayer();
        newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        animator.SetTrigger("Idle");
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Jump");
    }

}
