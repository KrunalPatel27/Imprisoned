using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public Canvas canvas;
    public Button start;
    public Button quit;
	public Button story;
	public Button controls;
    public AudioSource audioSource;
	public Button credits;

	// Use this for initialization
	void Start () {
        canvas = canvas.GetComponent<Canvas>();
        start = start.GetComponent<Button>();
        quit = quit.GetComponent<Button>();
		story = story.GetComponent<Button>();
		controls =  controls.GetComponent<Button>();
		credits =  credits.GetComponent<Button>();
	}

    // don't really need this...
    void update()
    {
//        if (GetComponent<AudioSource>().isPlaying)
//            GetComponent<AudioSource>().Play();
//        else
//            Debug.Log("Music Not Playing");
    }

    public void startButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cutscene");
    }

    // cant use quitButton since its used within unity
    public void exitButton()
    {
        Application.Quit();
    }
	public void storyButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Story");
	}
	public void controlsButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
	}
	public void creditsButton()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
	}
}
