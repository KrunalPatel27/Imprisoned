using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MontioringCameraMovement : MonoBehaviour {
	public float moveSpeed;
	private float localSpeed;

	public MontioringCamera camera;

	public double AngleInTime;
	private double localTime;
	public Slider healthBar;

	bool flag;
	bool colorChangeCollision = false;

	// Use this for initialization
	void Start () {
		localSpeed = moveSpeed;
		localTime = AngleInTime;
		//MontioringCamera.detectionFlag;
	}
	
	// Update is called once per frame
	void Update () {

		localTime -= Time.deltaTime;
		if (localTime < 0.0) {
			localSpeed = (-1) * localSpeed;
			localTime = AngleInTime;

		}

		transform.Rotate(0, 0, localSpeed);

	}

	public void setMoveSpeed()
	{
		moveSpeed = 0;
		localSpeed = 0;
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log("Spotted by the camera testing");
//		other.gameObject.tag == "DoorCameras";
		colorChangeCollision = true;
		healthBar.value += 30;
	//	Debug.Log ("This is healthbar" + healthBar.value);

	}

}
