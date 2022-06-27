using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill2_boss_behaviour : StateMachineBehaviour
{
    //private float timer;
    //public float minTime;
    //public float maxTime;

    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //timer = Random.Range(minTime, maxTime);
        boss = animator.GetComponent<Boss>();
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
        animator.SetTrigger("Idle");

        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Skill 2");
    }
}