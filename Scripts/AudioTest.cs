using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioTest : MonoBehaviour {

    //    private static AudioTest instance = null;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnLevelLoad (Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("Level Loaded: " + scene.name + " : " + loadSceneMode);
        if (scene.name.Equals("TestScene"))
        {
            audioSource.Stop();
        }
//        Debug.Log(loadSceneMode);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoad;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoad;
    }

    /*
    public static AudioTest Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    */
}
