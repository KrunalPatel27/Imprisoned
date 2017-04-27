using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public bool showMenu = false;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
//            showMenu = true;
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showMenu = true;
            }
            else
            {
                Time.timeScale = 1;
                showMenu = false;
            }
        }
	}

    void OnGUI()
    {
        if (showMenu)
        {
            //            GUI.Button(new Rect(10, 10, 100, 25), "Test");
//                Debug.Log("Clicked the button");
            GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 150), "Menu");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2, 80, 30), "Restart"))
                SceneManager.LoadScene("TestScene");
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 30), "Quit"))
                Application.Quit();
        }
    }
}
