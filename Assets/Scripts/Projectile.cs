using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private SpaceMarineController player;

	public Rigidbody2D platformPrefab;
	public Rigidbody2D trampolinePrefab;
	public Rigidbody2D boosterPrefab;

	private float x;
	private float rotationZ;
	private Vector3 ls;
	private Vector3 direction;
	private Vector3 destination;
	private Vector3 finalDestination;
	private int platformMode;


	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceMarineController> ();

		// determine which platform this projectile is suppsed to spawn
		platformMode = player.platformMode;

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

		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SpaceMarineController> ();
			if (player == null)
				return;
		}
		
		transform.position = Vector3.MoveTowards (transform.position, finalDestination,2.5f);

		if (finalDestination == transform.position) {
			switch(platformMode){
				case 1:
					Instantiate(platformPrefab, transform.position, Quaternion.identity);	
					break;
				case 2:
					Instantiate(trampolinePrefab, transform.position, Quaternion.identity);	
					break;
				case 3:
				Instantiate(boosterPrefab, transform.position,  Quaternion.Euler (0, 0, 90));	
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
	void OnTriggerEnter2D(Collider2D  col){
		if (col.gameObject.tag != "Projectile" && col.gameObject.tag != "Player")
			Destroy(gameObject);	
	}

}
