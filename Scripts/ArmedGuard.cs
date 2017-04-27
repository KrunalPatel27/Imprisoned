using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArmedGuard : MonoBehaviour {

    // for guard to move back and forth
    public float Speed;
    public double timer;
    private double LocalTimer;
    public float Angle;
    private float localAngle = 180;

    // for auto AI navigation
    public Transform target;
    public NavMeshAgent agent;

    public Animator animator;
    
    // field of vision shit
    public RaycastHit hit;
    public Vector3 rayDirection = Vector3.zero;
    public float rayDistance;
    public GameObject playerObject;
    public float fieldOfViewDegrees;
    public float distanceToPlayer;

    // for the animator shit
//    public Animator animatorObject;
    public AnimatorControllerParameter[] parameter;
    private int posInLisst = 0;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // fsm shit
        rayDistance = 150.0f;
        fieldOfViewDegrees = 68.0f;
        distanceToPlayer = 0.0f;
        LocalTimer = timer;

        // the name of the object EXACTLY in the heirarchy/scene in this case the gaurd needs to find the player
//        playerObject = GameObject.Find("Player");
          playerObject = GameObject.Find("FPSController");
        print("PLAYER: " + playerObject);
    }

    // code snippets inspired from unity forums/api documentation
    bool CanSeePlayer()
    {
        rayDirection = playerObject.transform.position - transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

//        print("rayDirection: " + rayDirection);
//        print("distanceToPlayer" + distanceToPlayer);

        // debug shit, creates a ray from the position of the guard to whatever is in view of it
        Ray ray = new Ray(transform.position, transform.forward);

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            print("1st");
            // detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance))
            {
                Debug.DrawLine(ray.origin, hit.point);
                print("2nd");
                return true;
            }
        }
        return false;
    }

	// Update is called once per frame
	void Update () {

        LocalTimer -= Time.deltaTime;
        
        // deal with seeing the player or not
        if (CanSeePlayer())
        {

            var rotate = Quaternion.LookRotation(playerObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 5f);

            print("distance: " + distanceToPlayer);

            // if distance is 100 or more and still seen
            // need to fix this, its not updating the distance with the FPS controller
            if (distanceToPlayer >= 100.0f)
            {
                animator.SetBool("DoWalkAim", true);
                animator.SetBool("DoAim", false);

                // probably don't need this for now
/*
                if (LocalTimer < 0.0)
                {
                    LocalTimer = timer;
                    animator.SetBool("DoAim", false);
                    animator.SetBool("DoWalkAim", false);
                }
*/
            }
            // otherwise youre pretty close to the guard
            else
            {
                animator.SetBool("DoAim", true);

                animator.SetBool("DoWalkAim", false);
                animator.SetBool("DoWalk", false);
            }
//            animator.speed = 1.5f;
        }
        else
        {
            // reset all the boolean animator shit to false
            AnimatorControllerParameter param;
            for (int i = 0; i < animator.parameters.Length; i++)
            {
                param = animator.parameters[i];

//                Debug.Log("Parameter Name: " + param.name);

                if (param.type == AnimatorControllerParameterType.Bool)
                {
//                    print("Parameter Name: " + param.name);
//                    print("Default Bool: " + param.defaultBool);
                    animator.SetBool(param.name, false);
                }
            }

/*
            if (distanceToPlayer >= 145.0f)
            {
                animator.SetBool("DoAim", false);
                if (LocalTimer != timer)
                    animator.SetBool("DoWalkAim", false);
            }
            else
                animator.SetBool("DoWalk", false);

*/

            // don't do this, otherwise aimation will freeze the momoment the player is out of sight
//            animator.speed = 0f;
        }

        //            transform.Translate(Vector3.forward * Speed);

        /*
        // after a certai time flip the orientation of the target
        if (LocalTimer < 0.0)
        {
            //Speed = (-1) * Speed;
            LocalTimer = timer;

            // turn the npc around
            // need to do it in arc fashion
            localAngle = (-1) * 180;
            Angle += localAngle;
            transform.eulerAngles = new Vector3(0, Angle, 0);
        }
        */
    }

    void OnDrawGizmosSelected()
    {

    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player")
        { }
    }
}
