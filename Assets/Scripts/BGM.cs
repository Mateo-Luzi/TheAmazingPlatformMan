using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	GameObject camera;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 150;

		// prevent multiple BGM objects from existing at once

		if(GameObject.FindObjectsOfType<BGM>().Length > 1)
			Destroy (gameObject);
		else // preserve BGM object when changing scenes
			DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
		// latch onto camera object when it's found
		if (camera == null)
			camera = GameObject.Find ("Main Camera");
		else
			gameObject.transform.position = camera.transform.position;
	}

}
