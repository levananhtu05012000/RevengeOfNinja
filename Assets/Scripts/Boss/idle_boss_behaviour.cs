using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle_boss_behaviour : StateMachineBehaviour
{
    private int rand;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        rand = Random.Range(0, 4);

        Debug.Log(rand);
        boss.LookAtPlayer();
        if (rand == 0) 
        {
            animator.SetTrigger("Jump");
        }
        else if (rand == 1)
        {
            animator.SetTrigger("Skill 1");
        }
        else if (rand == 2)
        {
            animator.SetTrigger("Approach");
        }
        else
        {
            animator.SetTrigger("Skill 2");
        }
        animator.ResetTrigger("Idle");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //
    }
}
