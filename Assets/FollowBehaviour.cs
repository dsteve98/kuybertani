using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    private Transform plantPos;
    public float speed;
    private float posDiff;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        plantPos = FindClosestEnemy(animator);
        animator.SetFloat("moveX", 1);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position == plantPos.position) animator.SetBool("isFollow", false);
        else
        {
            if (animator.transform.position.x > plantPos.transform.position.x) posDiff = -1;
            else posDiff = 1;
            animator.SetFloat("moveX", posDiff);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, plantPos.position, speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public Transform FindClosestEnemy(Animator animator)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("plant");
        if (gos.Length == 0)
        {
            animator.SetBool("isFollow", false);
            return animator.transform;
        }
        else
        {
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = animator.transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest.transform;
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
