using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMusic : MonoBehaviour {

	public AudioSource currentAudio;
	public AudioSource nextAudio;

	public MontioringCamera camera;

	bool flag;
	// Use this for initialization
	void Start () {
		GameObject theCamera = GameObject.Find("DoorCamera");
		MontioringCamera camera = theCamera.GetComponent<MontioringCamera>();

		nextAudio.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		//flag = MontioringCamera.detectionFlag;
		stopMusic ();
	}

	public void stopMusic()
	{
//		Debug.Log ("Start of StopMusic");
		if (MontioringCamera.detectionFlag == true) {
	//		Debug.Log ("Should start playing here");
			if (nextAudio.isPlaying == false) {
				nextAudio.Play ();
			}
			currentAudio.Stop();
		
		}
	}

}
