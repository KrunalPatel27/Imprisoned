using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUp : MonoBehaviour {
	public Text keyText;
	public Rigidbody key;
	private double LocalTimer;
	private bool keyCode = false;
	public float timer = 5f;
	public bool isPickedUp = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(keyCode && Input.GetKeyDown (KeyCode.Space)){
			key.gameObject.SetActive (false);
			keyText.enabled = true;
			keyText.text = "Key Picked up, Now find the Exit";
			LocalTimer = 3f;
			//isPickedUp = true;
		}
		UpdateTimer ();
	/*	if (keyText.enabled == true) {
			timer -= Time.deltaTime;
			Debug.Log ("This is timer" + timer);
			//yield return new WaitForSeconds (timer);
			if (timer <= 0.0) {
				keyText.text = "";
				keyText.enabled = false;
			}
		}*/
	}

	void UpdateTimer(){
//		Debug.Log ("Timer Test" + timer);
		if (isPickedUp) {
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
			
			keyText.text = "Press space to pick up Key";
			keyCode = true;
		/*	if (Input.GetKeyDown (KeyCode.Space)) {
				//key.gameObject.SetActive (false);
				print("success");
				secText.text = "success";
			}
*/
		}
	}

}
