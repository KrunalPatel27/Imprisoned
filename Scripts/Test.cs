﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : StateMachineBehaviour {

    // interact with the monobehavior
    public MonoTest monoTest;

    public GameObject[] player;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //        player = GameObject.Find("FPV");

        //       if ( monoTest.gameObject.CompareTag("FPV") )

//        if (monoTest.triggered)
//            animator.
//            Debug.Log("Found It");

        Debug.Log("OnStateEner");
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("OnStateUpdate");
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("OnStateExit");
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("OnStateMove");
    }

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
