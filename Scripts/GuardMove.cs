using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardMove : MonoBehaviour {
	// for guard to move back and forth
	public float Speed;
	public double timer;
	private double LocalTimer;
	public float Angle;
	private float localAngle =180;
	public bool state1 = false;
	// for auto AI navigation
	public Transform target;
	private NavMeshAgent agent;
	//all animation variables
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent>();
		LocalTimer = timer;
		state1 = false;
		anim.SetBool ("DoWalk", true);
	}
	
	// Update is called once per frame
	void Update () {
		
		//print ("This is guard" + state1);
		if (state1) {
			agent.SetDestination (target.position);
//			print ("chase active");
		} else {
			LocalTimer -= Time.deltaTime;
			transform.Translate (Vector3.forward * Speed);

			if (LocalTimer < 0.0) {
				//Speed = (-1) * Speed;
				LocalTimer = timer;

                // turn the npc around
                // need to do it in arc fashion
				localAngle = (-1) * 180;
				Angle += localAngle;
				transform.eulerAngles = new Vector3 (0, Angle, 0);
			}
		}
	}

	public void swapState(){
		state1 = !state1; 
	}

}
