using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
	// Start is called before the first frame update


	public float speed = 2.5f;
	public float attackRange = 3f;
	private Vector2 newPos;
	private Vector2 target;

	Transform player;
	Rigidbody2D rb;
	Boss boss;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		boss = animator.GetComponent<Boss>();
		target = new Vector2(player.position.x, rb.position.y);
		boss.LookAtPlayer();

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("Attack");
		}
        else
        {
			AudioManager.Play(AudioClipName.Boss_walking_1);
			newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
			rb.MovePosition(newPos);
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Attack");
	}
}
