using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {

	public AudioClip backgroundMusic;


	// Use this for initialization
	void Start () {
		audio.PlayOneShot(backgroundMusic);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
