using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	GameObject camera;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (camera == null)
			camera = GameObject.Find ("Main Camera");
		else
			gameObject.transform.position = camera.transform.position;

	}

}
