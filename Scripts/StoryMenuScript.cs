using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryMenuScript : MonoBehaviour {

	public Canvas canvas;
	public Button mainMenu;
	public Button Exit;
	public Button Restart;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		canvas = canvas.GetComponent<Canvas>();
		Exit = Exit.GetComponent<Button>();
		Restart = Restart.GetComponent<Button>();
		mainMenu = mainMenu.GetComponent<Button>();
	}

	public void mainMenuButtton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}
	public void ExitButton()
	{
		Application.Quit();
	}
	public void Restartbutton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("TestScene");
	}
}
