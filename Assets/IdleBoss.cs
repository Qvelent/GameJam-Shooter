using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IdleBoss : StateMachineBehaviour
{
    float timer;

    Transform player;
    float runRange = 10;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            animator.SetBool("IsWalk", true);
        }

        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance < runRange) 
        {
            animator.SetBool("IsRun", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

  
}
