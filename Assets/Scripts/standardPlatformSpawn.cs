using UnityEngine;
using System.Collections;

public class standardPlatformSpawn : MonoBehaviour {

	private SpaceMarineController player;
	BoxCollider2D[] playerBoxColliderList; 
	CircleCollider2D[] playerCircleColliderList;
	Vector3 distanceFromPlayer;
	// Use this for initialization
	void Start () {
		Invoke ("DestroyPlatform", 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerEnter2D(Collider2D  col){
		if (col.gameObject.tag == "Player") {
			Invoke ("DestroyPlatform", 2.0f);
		}
		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);
	}
	
	void DestroyPlatform() {
		Destroy (gameObject);
	}



}
