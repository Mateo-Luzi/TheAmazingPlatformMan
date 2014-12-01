using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody2D platformPrefab;
	public Rigidbody2D trampolinePrefab;

	private float x;
	private float rotationZ;
	private Vector3 ls;
	private Vector3 direction;
	private Vector3 destination;
	private Vector3 finalDestination;
	private int platformMode;


	void Start () {

		// determine which platform this projectile is suppsed to spawn
		platformMode = SpaceMarineController.platformMode;

		// make the projectile rotate to the cursor
		x = transform.localScale.x;
		ls = transform.localScale;
		direction = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		rotationZ = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotationZ);
		ls.x = x;
		transform.localScale = ls;

		// snapshot cursor position
		finalDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		finalDestination.z = 0;

		Destroy (gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.MoveTowards (transform.position, finalDestination,1.5f);

		if (finalDestination == transform.position) {
			switch(platformMode){
				case 1:
					Instantiate(platformPrefab, transform.position, Quaternion.identity);	
					break;
				case 2:
					Instantiate(trampolinePrefab, transform.position, Quaternion.identity);	
					break;
				}
			Destroy(gameObject);		
		}

	}

	// destroy projectile if it collides with anything other than the player or projectiles
	void OnCollisionEnter2D(Collision2D  col){
		if (col.gameObject.tag != "Projectile" && col.gameObject.tag != "Player")
			Destroy(gameObject);	
	}

}
