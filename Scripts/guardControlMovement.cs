using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guardControlMovement : MonoBehaviour {

	public Text keyText;
	//public ParticleSystem fire;
	private double LocalTimer;
	private bool keyCode = false;
	public float timer = 5f;
	public bool isActivated = false;
	// Use this for initialization
	public Camera camera1;
	public Camera camera2;
	public Camera camera3;

	public int count = 0;


	void Start () {
        // had to comment this out since it crashes on this line eveerytime i hit the play button to start the game
//		GetComponent<guardMovement>().enabled = true;
	}

	void Update () {

		if (keyCode && Input.GetKeyDown (KeyCode.C) && count == 0) {
			//fire.Play();
			keyText.enabled = true;

			count++;
			camera1.GetComponent<Camera> ().enabled = false;
			camera2.GetComponent<Camera> ().enabled = true;
			Debug.Log("THis is count" + count);

			/*
			 * Unable to reference guardMovement. Not in scope????
			 * 
			*/


			//GetComponent<guardMovement> ().enabled = true;
			//Debug.Log ("second test");
			keyText.text = "You are now able to see this guard's vision";
			LocalTimer = 3f;
			//isPickedUp = true;
		} else if (keyCode && Input.GetKeyDown (KeyCode.C) && count == 1) {
			camera1.GetComponent<Camera> ().enabled = false;
			camera3.GetComponent<Camera> ().enabled = true;

			count++;
			keyText.text = " ";
			Debug.Log("This is count when its 1: " + count);

		} else if (keyCode && Input.GetKeyDown (KeyCode.C) && count == 2) {
			camera1.GetComponent<Camera> ().enabled = true;
			camera3.GetComponent<Camera> ().enabled = false;

			count = 0;
			keyText.text = " ";
			Debug.Log("This is count when its 1: " + count);

		}
		UpdateTimer ();

	}

	void UpdateTimer(){
//		Debug.Log ("Timer Test" + timer);
		if (isActivated) {
			timer -= Time.deltaTime;
			//yield return new WaitForSeconds (timer);
//			Debug.Log ("This is timer" + timer);

			if (timer <= 0.0) {
				keyText.text = "";
				keyText.enabled = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		LocalTimer = 3;

		if (other.gameObject.CompareTag("Player"))
		{

			keyText.text = "Press C to control a guard.";
			keyCode = true;

		}
	}

}
