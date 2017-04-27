using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MontioringCamera : MonoBehaviour {
	public Text loseText;
	private GuardMove otherScript;
	private Chase skeleScript;
	public Light light;
	public static bool detectionFlag = false;

	public AudioClip startAudio;
	public AudioClip nextAudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void OnTriggerEnter(Collider other){
		
		if (other.gameObject.CompareTag ("Player")) {
			detectionFlag = true;
			light.GetComponent<Light>(); 
			light.color = Color.red;

			loseText.text = "You were Spotted by the Camera.";
			GuardMove otherScript = GameObject.Find("ArmyPilot").GetComponent<GuardMove>();
			GuardMove otherScript1 = GameObject.Find("ArmyPilot1").GetComponent<GuardMove>();
			Chase skelScript = GameObject.Find("Skeleton@Skin").GetComponent<Chase>();
			MontioringCameraMovement cameraScript = GameObject.Find ("DoorCamera").GetComponent<MontioringCameraMovement> ();
			//MontioringCameraMovement cameraScript1 = GameObject.Find ("DoorCamera (1)").GetComponent<MontioringCameraMovement> ();
			startMusic music = GameObject.Find ("Audio Source").GetComponent<startMusic> ();


			music.stopMusic ();
			otherScript.swapState();
			otherScript.Speed = 2.5f;
			otherScript1.swapState();
			otherScript1.Speed = 2.5f;
			skelScript.swapState ();
			cameraScript.setMoveSpeed ();
			//cameraScript1.setMoveSpeed ();

		}
	}
}
