using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDone : MonoBehaviour {

	public float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 8) {
			Application.LoadLevel ("Start");
		}
	}
}
