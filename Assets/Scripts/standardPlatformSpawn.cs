using UnityEngine;
using System.Collections;

public class standardPlatformSpawn : MonoBehaviour {



	// Use this for initialization
	void Start () {
		Destroy (gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnCollisionEnter2D(Collision2D  col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject, 2.0f);	
		}
		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);
	}
}
