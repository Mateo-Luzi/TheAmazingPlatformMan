using UnityEngine;
using System.Collections;

public class standardPlatformSpawn : MonoBehaviour {

	private SpaceMarineController player;
	BoxCollider2D[] playerBoxColliderList; 
	CircleCollider2D[] playerCircleColliderList;
	Vector3 distanceFromPlayer;
	Color defaultColor;
	float destroyDuration = 1.85f;
	bool fading = false;
	float lerp;
	Color colorFaded;

	// Use this for initialization
	void Start () {
		Invoke ("DestroyPlatform", 8.0f);
		defaultColor = gameObject.renderer.material.color;
		colorFaded = new Color (defaultColor.r, defaultColor.g, defaultColor.b, 0);
		lerp = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (fading) {
			lerp += Time.deltaTime / destroyDuration;
			renderer.material.color = Color.Lerp (defaultColor, colorFaded, lerp);
		}
	}

	void OnTriggerEnter2D(Collider2D  col){
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject, 2.0f);
			fading = true;
		}
		if (col.gameObject.tag == "Ground")
			Destroy(gameObject);
	}
	
	void DestroyPlatform() {
		fading = true;
		Destroy (gameObject, 2.0f);
	}



}
