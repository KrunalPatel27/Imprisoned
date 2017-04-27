using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoTest : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component on this gameobject.
    private Test exampleSmb; // Reference to a single StateMachineBehaviour.

    public GameObject player;

    public bool triggered = false;

    void Awake()
    {
        // Find a reference to the Animator component in Awake since it exists in the scene.
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        // Find a reference to the ExampleStateMachineBehaviour in Start since it might not exist yet in Awake.
        exampleSmb = animator.GetBehaviour<Test>();

        // Set the StateMachineBehaviour's reference to an ExampleMonoBehaviour to this.
        exampleSmb.monoTest = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FPV"))
        {
            Debug.Log("FoundTag");
            player = GameObject.FindGameObjectWithTag("ArmedGuard");
            //            exampleSmb.monoTest.animator.
            triggered = true;
            //            GameObject guard = ;

            GetComponent<Animator>().SetTrigger("Test");

            Animator testAnimate = player.GetComponent<Animator>();
            testAnimate.SetTrigger("Test");
        }
    }
}
