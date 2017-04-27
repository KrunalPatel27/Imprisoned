using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guardMovement : MonoBehaviour
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
	public GameObject script2;

	public Slider stealthBar;

	void Start()
	{
		//GetComponent<guardMovement> ().enabled = false;

		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator> ();
		flame.Stop ();
	//	camera1.GetComponent<Camera> ().enabled = false;
	//	camera2.GetComponent<Camera> ().enabled = true;
	//	GetComponent<guardMovement> ().enabled = false;
	//	GetComponent<PlayerMovement> ().enabled = false;

		//script2.GetComponent<Component> ().enabled = false;

		//camera1.GetComponent<Camera>().active = true;
		//camera2.GetComponent<Camera>().active = false;

	}


	void FixedUpdate()
	{
		GetComponent<guardMovement> ().enabled = true;

		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * m_TurnSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate (0,0,translation);
		transform.Rotate (0,rotation,0);

		/*	float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = transform.forward * moveVertical * speed * Time.deltaTime;
		rb.MovePosition(rb.position + movement);


		float turnValue = moveHorizontal * m_TurnSpeed * Time.deltaTime;
		Quaternion turn = Quaternion.Euler(0f, turnValue, 0f);
		rb.MoveRotation(rb.rotation * turn);
		*/
		if (Input.GetKeyDown(KeyCode.K)) {
			anim.SetBool ("isDancing", true);
		} else {
			anim.SetBool ("isDancing",false);
		}
		if (translation != 0.0) {
			if (translation == 1 || translation == -1) {
				print (translation);
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
			msg.text = "You Escaped Level 1! ";
		}
		if (other.gameObject.CompareTag ("SpotlightCollider")) {
			stealthBar.value += 30;
		}
		if (other.gameObject.CompareTag ("Particle System")) {
			flame.Play ();
		}

	}


}

