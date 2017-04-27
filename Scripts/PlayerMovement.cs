using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	//all animation variables
	public Animator anim;

	// all other variables
	public Rigidbody key;
	private Rigidbody rb;
	public float speed;                 // How fast the person moves
	public float m_TurnSpeed;            // How fast the person turns in degrees per second.
	private bool keyGrabbed = false;
	public Text msg;
	public ParticleSystem flame;
	//public GameObject camera2;
	//public GameObject camera1;
	public Camera camera1;
	public Camera camera2;
	public GameObject script1;
	//public GameObject script2;
	private const float coef = 0.4f;

	public Slider stealthBar;

	void Start()
	{
		//script1.GetComponent<guardMovement> ().enabled = false;
		script1.SetActive(true);
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		flame.Stop ();
	//	camera1.GetComponent<Camera> ().enabled = true;
	//	camera2.GetComponent<Camera> ().enabled = false;

		//GetComponent<guardMovement> ().enabled = false;
		//script2.GetComponent<Component> ().enabled = false;

		//camera1.GetComponent<Camera>().active = true;
		//camera2.GetComponent<Camera>().active = false;

	}


	void FixedUpdate()
	{

		if (stealthBar.value >= 280) {
			Application.LoadLevel ("GameOver");
		}
		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * m_TurnSpeed;
		translation *= Time.deltaTime;
		InvokeRepeating ("healthDecrease", 2f, 2f); //healthDecrease ();
		rotation *= Time.deltaTime;
		transform.Translate (0,0,translation);
		transform.Rotate (0,rotation,0);

		if (Input.GetKeyDown(KeyCode.K)) {
			anim.SetBool ("isDancing", true);
		} else {
			anim.SetBool ("isDancing",false);
		}
		if (translation != 0.0) {
			if (translation == 1 || translation == -1) {
//				print (translation);
				anim.SetBool ("isRunning", true);
			} else {
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isRunning", false);
			}
		} else {
			anim.SetBool ("isWalking", false);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("keyTag")) {
			keyGrabbed = true;
		}
		if (other.gameObject.CompareTag ("Finish") && keyGrabbed) {
			Application.LoadLevel ("Credits");

		}
		if (other.gameObject.CompareTag ("spotlight")) {
			stealthBar.value += 80;
			//Debug.Log ("Health bar went up by 30");
			//Debug.Log (stealthBar.value);
		}
		if (other.gameObject.CompareTag ("Guard")) {
			stealthBar.value += 100;
			//Debug.Log ("Health bar went up by 30");
			//Debug.Log (stealthBar.value);
		}
/*		if (other.gameObject.CompareTag ("Particle System")) {
			flame.Play ();
		}*/
	}

	public void healthDecrease(){

		if(stealthBar.value != 0) {
			stealthBar.value -= Time.deltaTime * coef;
		}
	}


}

