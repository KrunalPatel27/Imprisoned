using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightTrigger : MonoBehaviour {

	public GameObject otherlight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		}
	public void OnTriggerEnter(Collider other){

		//if (other.gameObject.CompareTag ("Player")) {
			
			//GetComponent<> ().material.color = Color.white;	
		//}
		otherlight = GameObject.FindWithTag("Spotlight");
	}
}
