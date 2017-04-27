using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playVideo : MonoBehaviour {

	public MovieTexture movietext;
	RawImage raw;
	AudioSource audiosrc;

	// Use this for initialization
	void Start () {
		raw = GetComponent<RawImage> ();
	
		audiosrc = GetComponent<AudioSource> ();
		playClip();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playClip()
	{
		raw.texture = movietext;
		movietext.Play ();
		audiosrc.Play ();
	}
}
