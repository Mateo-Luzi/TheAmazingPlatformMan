using UnityEngine;
using System.Collections;

public class standardPlatformSpawn : MonoBehaviour {

	private SpaceMarineController player;
	BoxCollider2D[] playerBoxColliderList; 
	CircleCollider2D[] playerCircleColliderList;
	Vector3 distanceFromPlayer;
	// Use this for initialization
	void Start () {

		// experimental jump-through code
		player = GameObject.Find ("Character").GetComponent<SpaceMarineController> ();
		playerBoxColliderList = player.gameObject.GetComponents<BoxCollider2D> ();
		playerCircleColliderList = player.gameObject.GetComponents<CircleCollider2D> ();
		distanceFromPlayer =  transform.position - player.transform.position;
	

		// dont let player spawn platform inside himself
		// good luck making this work
//		if ((distanceFromPlayer.y < 3.5 && distanceFromPlayer.y > -5) && (distanceFromPlayer.x < -2 && distanceFromPlayer.y > 2))
//			Destroy (gameObject);

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


		// experimental jump-through code
		CancelInvoke("DestroyPlatform");
		if(!player.grounded || distanceFromPlayer.y > 0.0f )
			foreach (BoxCollider2D b in playerBoxColliderList) 
				b.isTrigger = true;		
		if(!player.grounded)
			foreach (CircleCollider2D c in playerCircleColliderList) 
				c.isTrigger = true;	


	}

	// experimental jump-through code
	void OnTriggerExit2D(Collider2D  col){
		foreach (BoxCollider2D b in playerBoxColliderList) 
			b.isTrigger = false;		
		foreach (CircleCollider2D c in playerCircleColliderList) 
			c.isTrigger = false;

		player.grounded = true;
		Invoke ("DestroyPlatform", 2.0f);
	}


	void DestroyPlatform() {
		Destroy (gameObject);
	}



}
