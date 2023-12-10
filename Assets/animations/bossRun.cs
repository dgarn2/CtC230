using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRun : StateMachineBehaviour
{
    
public float speed = 2.5f;
Transform player;
Rigidbody2D rb;
Transform bossPos;
private combat playerHP;
private float timer=0;
public float next=0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<combat>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossPos =  animator.GetComponent<Transform>();
    //    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector3.Distance(player.position, bossPos.position)>50){
            return;
        }
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        

        if ((Vector2.Distance(player.position, new Vector2(bossPos.position.x, bossPos.position.y)) < 1.1) && ((timer-next)  > 140)){
           Debug.Log(combat.playerHealth -= 1);
            next = timer;
           //Debug.Log(GameObject.FindGameObjectWithTag("Player"));
        }

        if ((target.x - bossPos.position.x) > 0){
            bossPos.GetComponent<SpriteRenderer>().flipX=false;
        }else{
           bossPos.GetComponent<SpriteRenderer>().flipX=true;
        }


        timer+=1;

	
    }


    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
