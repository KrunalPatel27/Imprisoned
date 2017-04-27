using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    // getting caught shit
    public bool caught = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // triggered
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            caught = true;
    }


    void OnGUI()
    {
        if (caught)
        {
            //            GUI.Button(new Rect(10, 10, 100, 25), "Test");
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Game Over!");
            GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2, 80, 30), "Restart");
        }
    }
}
