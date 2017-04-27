using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireExtinguisher : MonoBehaviour {
	
		public Text keyText;
		public ParticleSystem fire;
		private double LocalTimer;
		private bool keyCode = false;
		public float timer = 5f;
		public bool isActivated = false;
		// Use this for initialization
		public Camera camera1;
		public Camera camera2;


		void Start () {
		
		}
		
		void Update () {

			if(keyCode && Input.GetKeyDown (KeyCode.Space)){
				fire.Play();
				keyText.enabled = true;
			//	camera1.GetComponent<Camera> ().enabled = false;
			//	camera2.GetComponent<Camera> ().enabled = true;

				keyText.text = "A fire has now been set. A nearby guard will come to inspect this.";
				LocalTimer = 3f;
				//isPickedUp = true;
			}
			UpdateTimer ();

		}

		void UpdateTimer(){
//			Debug.Log ("Timer Test" + timer);
			if (isActivated) {
				timer -= Time.deltaTime;
				//yield return new WaitForSeconds (timer);
				Debug.Log ("This is timer" + timer);

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

				keyText.text = "Press space to activate fire.";
				keyCode = true;

			}
		}

	}
