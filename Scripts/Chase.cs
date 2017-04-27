using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

	public float Speed;
	public double timer;
	private double LocalTimer;
	public float Angle;
	private float localAngle =180;
	public bool state1 = false;

	public Transform target;
	NavMeshAgent agent;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		LocalTimer = timer;
		state1 = false;
	}

	// Update is called once per frame
	void Update () {

	if (state1) {
			agent.SetDestination (target.position);
		} else {
			LocalTimer -= Time.deltaTime;
			transform.Translate (Vector3.forward * Speed);
			if (LocalTimer < 0.0) {
				//Speed = (-1) * Speed;
				LocalTimer = timer;
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
